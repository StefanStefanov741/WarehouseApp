using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using WarehouseApp.Entities;

namespace WarehouseApp.DataAccess
{
    public class UsersRepo
    {
        private readonly IConfiguration configuration;
        string connectionString = "";
        SqlConnection connection = null;
        private List<User> users;


        public UsersRepo(IConfiguration config) {
            this.configuration = config;
            this.connectionString = configuration.GetConnectionString("DefaultConnectionString");
            this.connection = new SqlConnection(connectionString);
        }

        void RefreshUserList() {
            users = new List<User>();
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Users", connection);
            var dataReader = command.ExecuteReader();
            var type = typeof(User);
            while (dataReader.Read()) {
                User u = (User)Activator.CreateInstance(type);
                foreach (var prop in type.GetProperties()) {
                    var propType = prop.PropertyType;
                    prop.SetValue(u, Convert.ChangeType(dataReader[prop.Name].ToString(),propType));
                }
                users.Add(u);
            }
            connection.Close();
        }

        public User TryLoginUser(string username, string password)
        {
            RefreshUserList();
            User temp_user = users.Where(u => u.Username == username && u.Password == password).FirstOrDefault();
            return temp_user;
        }

        public void AddUser(User newUser)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO Users (Username, Password, Email,Phone)VALUES('"+newUser.Username+ "','" + newUser.Password + "','" + newUser.Email + "','" + newUser.Phone + "');", connection);
            command.ExecuteScalar();
            connection.Close();
            RefreshUserList();
        }

        public User GetUserByUsername(string username)
        {
            RefreshUserList();
            User temp_user = users.Where(u => u.Username == username).FirstOrDefault();
            return temp_user;
        }

        public User GetUserByEmail(string email)
        {
            RefreshUserList();
            User temp_user = users.Where(u => u.Email == email).FirstOrDefault();
            return temp_user;
        }
    }
}
