using Microsoft.AspNetCore.Mvc;
using WarehouseApp.DataAccess;
using Microsoft.Extensions.Configuration;
using WarehouseApp.Models;
using WarehouseApp.Entities;
using Microsoft.AspNetCore.Http;
using WarehouseApp.ActionFilters;
using System.Text.RegularExpressions;
using System.Text;
using System.Security.Cryptography;

namespace WarehouseApp.Controllers
{
    [AuthenticationFilter]
    public class UsersController : Controller
    {
        UsersRepo repo;
        public UsersController(IConfiguration config) {
            repo = new UsersRepo(config);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }


        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            User TempUser = repo.TryLoginUser(model.Username, EncryptPassword(model.Password));
            if (TempUser == null)
            {
                ModelState.AddModelError("AuthenticationFailed", "Wrong username or password !");
                return View(model);
            }
            this.HttpContext.Session.SetString("LoggedIn", TempUser.Username);
            return RedirectToAction("Index", "Products");
        }
        public IActionResult Logout()
        {
            this.HttpContext.Session.Remove("LoggedIn");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }

        string usernameChars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM_";
        string emailRegex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";
        string passwordNumberChars = "0123456789";
        string passwordSmallChars = "qwertyuiopasdfghjklzxcvbnm";
        string passwordCapsChars = "QWERTYUIOPASDFGHJKLZXCVBNM";
        string passwordSpecialChars = "@-_~|";
        string phoneCharacters = "01234566789 -";

        [HttpPost]
        public IActionResult Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //Username validation
            bool nameError = false;
            User TestUser = repo.GetUserByUsername(model.Username);
            if (TestUser != null)
            {
                ModelState.AddModelError("UsernameError", "This username is already taken !");
                nameError = true;
            }
            if (!nameError&&(model.Username.Length < 5 || model.Username.Length > 15)) {
                ModelState.AddModelError("UsernameError", "The username must be between 5 and 15 characters.");
                nameError = true;
            }
            if (!nameError)
            {
                foreach (char c in model.Username) {
                    if (!usernameChars.Contains(c)) {
                        ModelState.AddModelError("UsernameError", "Invalid username! The character "+c+" is not allowed!");
                        nameError = true;
                        break;
                    }
                }
            }

            //Password validation
            bool passwordError = false;
            if (model.Password.Length < 6 || model.Password.Length > 20)
            {
                ModelState.AddModelError("PasswordError", "Password must be between 6 and 20 characters.");
                passwordError = true;
            }
            if (!passwordError)
            {
                foreach (char c in model.Password)
                {
                    if (!passwordNumberChars.Contains(c) && !passwordSmallChars.Contains(c)&&!passwordCapsChars.Contains(c)&&!passwordSpecialChars.Contains(c))
                    {
                        ModelState.AddModelError("PasswordError", "Password contains invalid characters!");
                        passwordError = true;
                        break;
                    }
                }
            }
            if (!passwordError)
            {
                bool smallChar = false;
                bool capsChar = false;
                bool specialChar = false;

                foreach (char c in passwordSmallChars)
                {
                    if (model.Password.Contains(c))
                    {
                        smallChar = true;
                        break;
                    }
                }
                foreach (char c in passwordCapsChars)
                {
                    if (model.Password.Contains(c))
                    {
                        capsChar = true;
                        break;
                    }
                }
                foreach (char c in passwordSpecialChars)
                {
                    if (model.Password.Contains(c))
                    {
                        specialChar = true;
                        break;
                    }
                }

                if (!smallChar || !capsChar || !specialChar) {
                    ModelState.AddModelError("PasswordError", "Password must contain at least 1 lower case character, at least 1 upper case character and at least 1 special character [@, -, _, ~, |]");
                    passwordError = true;
                }
            }

            //Email validation
            TestUser = null;
            bool emailError = false;
            TestUser = repo.GetUserByEmail(model.Email);
            if (TestUser != null)
            {
                ModelState.AddModelError("EmailError", "This email is already registered !");
                emailError = true;
            }
            if (!emailError && !Regex.IsMatch(model.Email, emailRegex, RegexOptions.IgnoreCase))
            {
                ModelState.AddModelError("EmailError", "Invalid Email.");
                nameError = true;
            }
            if (!emailError && (model.Email.Length > 100))
            {
                ModelState.AddModelError("EmailError", "This email is too long! Max character limit for an email is 100.");
                nameError = true;
            }

            //Phone validation
            bool phoneError = false;
            if (model.Phone!=null) {
                if (model.Phone.Length > 15) {
                    ModelState.AddModelError("PhoneError", "Max phone length is 15 characters.");
                    phoneError = true;
                }
                if (!phoneError)
                {
                    foreach (char c in model.Phone) {
                        if (!phoneCharacters.Contains(c)) {
                            ModelState.AddModelError("PhoneError", "Phone contains a forbidden character.");
                            phoneError = true;
                            break;
                        }
                    }
                }
            }

            //Return error if something went wrong
            if (nameError || passwordError || emailError || phoneError) {
                return View(model);
            }

            //Create new user and add him to the DB
            User NewUser = new User();
            NewUser.Username = model.Username;
            NewUser.Password = EncryptPassword(model.Password);
            NewUser.Email = model.Email;
            NewUser.Phone = model.Phone;
            repo.AddUser(NewUser);
            this.HttpContext.Session.SetString("LoggedIn", NewUser.Username);

            //Redirect the logged in user to the home page
            return RedirectToAction("Index", "Home");
        }

        string EncryptPassword(string pass) {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                //ComputeHash
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(pass));

                //Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
