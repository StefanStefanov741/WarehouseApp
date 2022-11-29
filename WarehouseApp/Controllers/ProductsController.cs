using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using WarehouseApp.ActionFilters;
using WarehouseApp.DataAccess;
using WarehouseApp.Entities;
using WarehouseApp.Models;

namespace WarehouseApp.Controllers
{
    [AuthenticationFilter]
    public class ProductsController : Controller
    {
        ProductsRepo repo;
        public ProductsController(IConfiguration config)
        {
            repo = new ProductsRepo(config);
        }

        [HttpGet]
        public IActionResult Index(string searchName = null, string searchCategory = null, string searchCode = null, int page = 0, int pages = 0, bool prevPage = false,bool nextPage=false)
        {
            if (searchName == null && searchCategory == null && searchCode == null)
            {
                return View();
            }
            else {
                InventorySearchVM model = searchInv(searchName,searchCategory,searchCode,page,pages,prevPage,nextPage);
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Index(InventorySearchVM model)
        {
            model = searchInv(model.Name,model.Category,model.Code);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(NewProductVM model)
        {
            //validate input fields
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            bool nameError = false;
            if (model.Name.Length > 50)
            {
                ModelState.AddModelError("NameValidation","Name characters exceeded by: "+(model.Name.Length - 50)+" characters.");
                nameError = true;
            }
            bool descError = false;
            if (model.Description == null) {
                model.Description = "";
            }
            if (model.Description.Length > 2000)
            {
                ModelState.AddModelError("DescriptionValidation","Description characters exceeded by: "+(model.Description.Length - 2000)+" characters.");
                descError = true;
            }
            bool buyPriceError = false;
            if (model.BuyPrice < 0)
            {
                ModelState.AddModelError("BPValidation", "The buy price cannot be below 0!");
                buyPriceError = true;
            }
            bool sellPriceError = false;
            if (model.SellPrice < 0)
            {
                ModelState.AddModelError("SPValidation", "The sell price cannot be below 0!");
                sellPriceError = true;
            }
            bool quantError = false;
            if (model.Quantity <0)
            {
                ModelState.AddModelError("QuantityValidation", "The quantity cannot be below 0!");
                quantError = true;
            }
            bool codeError = false;
            if (model.Code.Length > 50)
            {
                ModelState.AddModelError("CodeValidation", "Code characters exceeded by: " + (model.Code.Length - 50) + " characters.");
                codeError = true;
            }
            else if (repo.GetProductByCode(model.Code) != null)
            {
                ModelState.AddModelError("CodeValidation", "Code already exists in the database!");
                codeError = true;
            }
            else {
                string forbiddenChars = "#%&{}\\<>*?/$!'\":@+`|=";
                foreach (char c in model.Code) {
                    if (forbiddenChars.Contains(c)) {
                        ModelState.AddModelError("CodeValidation", "Invalid Code! The character "+c+" is not allowed!");
                        codeError = true;
                        break;
                    }
                }
            }
            if (nameError || descError || buyPriceError || sellPriceError || quantError || codeError) {
                return View(model);
            }
            //save product in the DB
            Product new_prod = new Product();
            new_prod.Name = model.Name;
            new_prod.Description = model.Description;
            new_prod.Code = model.Code;
            new_prod.BuyPrice = model.BuyPrice;
            new_prod.SellPrice = model.SellPrice;
            new_prod.Quantity = model.Quantity;
            new_prod.Category = model.Category;
            if (model.Image != null)
            {
                //save the image on the server with a unique name
                using (var fileSteram = new FileStream("../WarehouseApp/wwwroot/images/Product_Images/" + model.Code + ".png", FileMode.Create, FileAccess.Write))
                {
                    model.Image.CopyTo(fileSteram);
                }
            }
            repo.AddProduct(new_prod);
            //redirect to inventory
            return RedirectToAction("Index", "Products");
        }

        [HttpGet]
        public IActionResult EditProduct(string code,string searchName, string searchCode, string searchCategory,int page,int pages)
        {
            try
            {
                Product p = repo.GetProductByCode(code);
                EditProductVM editModel = new EditProductVM();
                editModel.OriginalCode = code;
                editModel.ID = p.ID;
                editModel.Name = p.Name;
                editModel.Description = p.Description;
                editModel.BuyPrice = p.BuyPrice;
                editModel.SellPrice = p.SellPrice;
                editModel.Quantity = p.Quantity;
                editModel.Category = p.Category;
                editModel.Code = p.Code;
                editModel.searchCode = searchCode;
                editModel.searchName = searchName;
                editModel.searchCategory = searchCategory;
                editModel.page = page;
                editModel.pages = pages;
                return View(editModel);
            }
            catch {
                //go back to the inventory page with applied filters
                InventorySearchVM searchModel = searchInv(searchName,searchCategory,searchCode);
                return View("Index", searchModel);
            }
        }

        [HttpPost]
        public IActionResult EditProduct(EditProductVM model)
        {
            //Validate required fields
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool issuesFound = false;

            //Check if another product is using the edited code
            Product productWithSameCode = repo.GetProductByCode(model.Code);
            if (productWithSameCode != null && productWithSameCode.ID != model.ID) {
                issuesFound = true;
                ModelState.AddModelError("CodeValidation", "That Code is used by a different product!");
            }

            //Validate input fields
            if (model.Name.Length > 50)
            {
                ModelState.AddModelError("NameValidation", "Name characters exceeded by: " + (model.Name.Length - 50) + " characters.");
                issuesFound = true;
            }

            if (model.Description == null)
            {
                model.Description = "";
            }
            if (model.Description.Length > 2000)
            {
                ModelState.AddModelError("DescriptionValidation", "Description characters exceeded by: " + (model.Description.Length - 2000) + " characters.");
                issuesFound = true;
            }

            if (model.BuyPrice < 0)
            {
                ModelState.AddModelError("BPValidation", "The buy price cannot be below 0!");
                issuesFound = true;
            }

            if (model.SellPrice < 0)
            {
                ModelState.AddModelError("SPValidation", "The sell price cannot be below 0!");
                issuesFound = true;
            }

            if (model.Quantity < 0)
            {
                ModelState.AddModelError("QuantityValidation", "The quantity cannot be below 0!");
                issuesFound = true;
            }

            if (model.Code.Length > 50)
            {
                ModelState.AddModelError("CodeValidation", "Code characters exceeded by: " + (model.Code.Length - 50) + " characters.");
                issuesFound = true;
            }
            else
            {
                string forbiddenChars = "#%&{}\\<>*?/$!'\":@+`|=";
                foreach (char c in model.Code)
                {
                    if (forbiddenChars.Contains(c))
                    {
                        ModelState.AddModelError("CodeValidation", "Invalid Code! The character " + c + " is not allowed!");
                        issuesFound = true;
                        break;
                    }
                }
            }

            if (issuesFound) {
                return View(model);
            }
            //Rename previously uploaded image for this product in if the Code was changed
            if (model.OriginalCode!=model.Code) {
                if (System.IO.File.Exists("../WarehouseApp/wwwroot/images/Product_Images/" + model.OriginalCode + ".png"))
                {
                    System.IO.File.Move("../WarehouseApp/wwwroot/images/Product_Images/" + model.OriginalCode + ".png", "../WarehouseApp/wwwroot/images/Product_Images/" + model.Code + ".png");
                }
            }
            //Update the product
            Product p = new Product();
            p.ID = model.ID;
            p.Name = model.Name;
            p.BuyPrice = model.BuyPrice;
            p.SellPrice = model.SellPrice;
            p.Description = model.Description;
            p.Category = model.Category;
            p.Code = model.Code;
            p.Quantity = model.Quantity;
            if (model.Image != null)
            {
                //save the image on the server with a unique name
                using (var fileSteram = new FileStream("../WarehouseApp/wwwroot/images/Product_Images/" + p.Code + ".png", FileMode.Create, FileAccess.Write))
                {
                    model.Image.CopyTo(fileSteram);
                }
            }
            repo.UpdateProduct(p);

            return RedirectToAction("Index", new { searchName = model.searchName, searchCategory = model.searchCategory, searchCode=model.searchCode, page=model.page, pages = model.pages });
        }

        [HttpPost]
        public IActionResult DeleteProduct(string codeToDel,string searchName, string searchCategory, string searchCode, int page=0, int pages=0) {
            //delete product from DB
            repo.DeleteProductByCode(codeToDel);
            //delete picture of product if it exists
            if (System.IO.File.Exists("../WarehouseApp/wwwroot/images/Product_Images/" + codeToDel+".png"))
            {
                System.IO.File.Delete("../WarehouseApp/wwwroot/images/Product_Images/" + codeToDel + ".png");
            }
            //perform new search on the page
            InventorySearchVM searchModel = searchInv(searchName, searchCategory, searchCode,page,pages);
            return View("Index", searchModel);
        }


        //Inventory filter method
        public InventorySearchVM searchInv(string searchName, string searchCategory, string searchCode, int page = 0, int pages = 0,bool prevPage = false, bool nextPage = false) {
            InventorySearchVM searchModel = new InventorySearchVM();
            searchModel.Name = searchName;
            searchModel.Category = searchCategory;
            searchModel.Code = searchCode;

            if (searchModel.Code != null && !searchModel.Code.Equals(""))
            {
                //search by code
                searchModel.products = new List<Product> { repo.GetProductByCode(searchModel.Code) };
            }
            else
            {
                if ((searchModel.Name == null || searchModel.Name.Equals("")) && (searchModel.Category == null || searchModel.Category.Equals("") || searchModel.Category.Equals("Всички")))
                {
                    //search all
                    searchModel.products = repo.GetAllProducts();
                }
                else if ((searchModel.Name != null && !searchModel.Name.Equals("")) && (searchModel.Category != null && !searchModel.Category.Equals("") && !searchModel.Category.Equals("Всички")))
                {
                    //search by name and category
                    searchModel.products = repo.GetProductsByNameAndCategory(searchModel.Name, searchModel.Category);
                }
                else if ((searchModel.Name != null && !searchModel.Name.Equals("")) && (searchModel.Category == null || searchModel.Category.Equals("") || searchModel.Category.Equals("Всички")))
                {
                    //search by name
                    searchModel.products = repo.GetProductsByName(searchModel.Name);
                }
                else if ((searchModel.Name == null || searchModel.Name.Equals("")) && (searchModel.Category != null && !searchModel.Category.Equals("") && !searchModel.Category.Equals("Всички")))
                {
                    //search by category
                    searchModel.products = repo.GetProductsByCategory(searchModel.Category);
                }
            }
            searchModel.all_products = searchModel.products;
            if (searchModel.products.Count > 10) {
                if (page == 0)
                {
                    searchModel.products = searchModel.all_products.GetRange(0, 10);
                    searchModel.page = 1;
                    searchModel.pages = (searchModel.all_products.Count + 9) / searchModel.products.Count;
                }
                else {
                    if (nextPage&&(page+1)<=pages) {
                        page++;
                    }
                    if (prevPage&&(page-1)>=1) {
                        page--;
                    }
                    int takeFromProduct = (page - 1) * 10;
                    int takeProducts = 10;
                    if (searchModel.all_products.Count < takeProducts + takeFromProduct)
                    {
                        takeProducts = searchModel.all_products.Count - takeFromProduct;
                    }
                    searchModel.products = searchModel.all_products.GetRange(takeFromProduct, takeProducts);
                    searchModel.page = page;
                    if (pages == 0)
                    {
                        searchModel.pages = (searchModel.all_products.Count + 9) / searchModel.products.Count;
                    }
                    else
                    {
                        searchModel.pages = pages;
                    }

                    //check for when we might delete the last item on a page and we need to remove that page as well
                    if (searchModel.products.Count == 0) {
                        pages -= 1;
                        page-=1;

                        takeFromProduct = (page - 1) * 10;
                        takeProducts = 10;
                        if (searchModel.all_products.Count < takeProducts + takeFromProduct)
                        {
                            takeProducts = searchModel.all_products.Count - takeFromProduct;
                        }
                        searchModel.products = searchModel.all_products.GetRange(takeFromProduct, takeProducts);
                        searchModel.page = page;
                        if (pages == 0)
                        {
                            searchModel.pages = (searchModel.all_products.Count + 9) / searchModel.products.Count;
                        }
                        else
                        {
                            searchModel.pages = pages;
                        }
                    }

                    //check if last page shouldnt exist after deleting from current page
                    if ((float)pages > (((float)searchModel.all_products.Count+9.0) / searchModel.products.Count))
                    {
                        searchModel.pages--;
                    }

                }
            }
            return searchModel;
        }

    }
}
