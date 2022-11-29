using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using WarehouseApp.Entities;
namespace WarehouseApp.DataAccess
{
    public class ProductsRepo
    {
        private readonly IConfiguration configuration;
        string connectionString = "";
        SqlConnection connection = null;
        private List<Product> products;

        public ProductsRepo(IConfiguration config)
        {
            this.configuration = config;
            this.connectionString = configuration.GetConnectionString("DefaultConnectionString");
            this.connection = new SqlConnection(connectionString);
        }

        void RefreshProductsList()
        {
            products = new List<Product>();
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Products", connection);
            var dataReader = command.ExecuteReader();
            var type = typeof(Product);
            while (dataReader.Read())
            {
                Product p = (Product)Activator.CreateInstance(type);
                foreach (var prop in type.GetProperties())
                {
                    var propType = prop.PropertyType;
                    prop.SetValue(p, Convert.ChangeType(dataReader[prop.Name].ToString(), propType));
                }
                products.Add(p);
            }
            connection.Close();
        }

        public void AddProduct(Product newProd)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO Products (Name, Description,BuyPrice,SellPrice,Quantity,Category,Code)VALUES(N'"+newProd.Name+ "',N'" + newProd.Description+ "'," + newProd.BuyPrice.ToString().Replace(",", ".") + "," + newProd.SellPrice.ToString().Replace(",", ".") + "," + newProd.Quantity+ ",N'" + newProd.Category+ "','" + newProd.Code+ "');", connection);
            command.ExecuteScalar();
            connection.Close();
            RefreshProductsList();
        }

        public List<Product> GetAllProducts() {
            RefreshProductsList();
            return products;
        }

        public List<Product> GetProductsByName(string name)
        {
            RefreshProductsList();
            List<Product> temp_list = products.Where(p => p.Name.ToLower().Contains(name.ToLower())).ToList();
            return temp_list;
        }

        public List<Product> GetProductsByCategory(string category)
        {
            RefreshProductsList();
            List<Product> temp_list = products.Where(p => p.Category.ToLower().Equals(category.ToLower())).ToList();
            return temp_list;
        }

        public Product GetProductByCode(string code)
        {
            RefreshProductsList();
            Product prod = products.Where(p => p.Code.Equals(code)).FirstOrDefault();
            return prod;
        }

        public List<Product> GetProductsByNameAndCategory(string name,string category)
        {
            RefreshProductsList();
            List<Product> temp_list = products.Where(p => p.Category.ToLower().Equals(category.ToLower()) && p.Name.ToLower().Contains(name.ToLower())).ToList();
            return temp_list;
        }

        public void UpdateProduct(Product prod) {
            connection.Open();
            SqlCommand command = new SqlCommand("UPDATE Products SET Name=N'"+prod.Name+ "', Description=N'" + prod.Description + "', Code='" + prod.Code + "', BuyPrice=" + prod.BuyPrice.ToString().Replace(",", ".") + ", SellPrice=" + prod.SellPrice.ToString().Replace(",", ".") + ", Quantity=" + prod.Quantity + ", Category=N'" + prod.Category + "' WHERE ID='" + prod.ID+"';", connection);
            command.ExecuteScalar();
            connection.Close();
            RefreshProductsList();
        }

        public void DeleteProductByCode(string code) {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Products WHERE Code = '"+code+"';", connection);
            command.ExecuteScalar();
            connection.Close();
            RefreshProductsList();
        }

    }
}
