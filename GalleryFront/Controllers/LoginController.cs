using Gallery.Models;
using Gallery.ViewModels;
using GalleryBusiness.Encrypt;
using GalleryBusiness.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace GalleryFront.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserLogin _userlogin;
        public LoginController(IUserLogin userLogin)
        {
            _userlogin = userLogin;
        }
        public IActionResult Login()
        {
            var loggedInUser = HttpContext.User;
            var loggedInUserName = loggedInUser.Identity.Name;
            ViewBag.username = loggedInUserName;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel Ulogin)
        {
            if (_userlogin.CheckPass(Ulogin) == true && _userlogin.isAdmin(Ulogin.Username))
            {
                var ownRole = new List<Claim>();
                ownRole.Add(new Claim(ClaimTypes.Role, "admin"));//databaseden gelen nesnenın
                ownRole.Add(new Claim(ClaimTypes.Name, Ulogin.Username));
                ownRole.Add(new Claim(ClaimTypes.Hash, Sha256.ComputeSha256Hash(Ulogin.Password)));
                var ownIdentity = new ClaimsIdentity(ownRole, CookieAuthenticationDefaults.AuthenticationScheme);
                var ownPrincipal = new ClaimsPrincipal(ownIdentity);
                var ownSchema = CookieAuthenticationDefaults.AuthenticationScheme;
                await HttpContext.SignInAsync(ownSchema, ownPrincipal);
                HttpContext.Session.SetString("currentUser", Ulogin.Username);
                return RedirectToAction("Index", "Home");
            }
            else
                return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserLoginModel userLoginModel)
        {
            _userlogin.Register(userLoginModel);
            return RedirectToAction("Login");
        }
        public async Task<IActionResult> logOut()
        {
            if (HttpContext.Request.Cookies.Count > 0)
            {
                var siteCookies = HttpContext.Request.Cookies.Where(c => c.Key.Contains(".AspNetCore.") || c.Key.Contains("Microsoft.Authentication"));
                foreach (var cookie in siteCookies)
                {
                    Response.Cookies.Delete(cookie.Key);
                }
            }
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
