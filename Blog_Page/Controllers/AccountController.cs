﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Blog_Page.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Blog_Page.Controllers
{
    public class AccountController : Controller
    {
        const string cookieString = "Cookies";
        private readonly BlogPageContext _blogPageContext;
        public AccountController(BlogPageContext blogPageContext)
        {
            _blogPageContext = blogPageContext;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return PartialView("Regestration");
        }
        [HttpPost]
        public async Task<IActionResult> Registration(BlogUser blogUser)
        {
            if (_blogPageContext.BlogUsers.Any(c => c.Email == blogUser.Email))
            {
                return Content($" {blogUser.Email} Вже зареєстрований ;) ");
            }
            var userr = await _blogPageContext.BlogUsers.AddAsync(new BlogUser
            {
                Id = Guid.NewGuid().ToString(),
                Email = blogUser.Email,
                Password = blogUser.Password,
                Role = "Default"
            });
            await _blogPageContext.SaveChangesAsync();


            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, blogUser.Email),
                    new Claim("role", "Default"),
                };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, cookieString);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(cookieString, claimsPrincipal);

            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public IActionResult SignInAuthorization()
        {
            return PartialView("SignInAuthorization");


        }


        [HttpPost]
        public async Task<IActionResult> SignInAuthorization(BlogUser blogUser)
        {


            var _httpcontext = HttpContext;
            //await _CustomCookiAddService.customCookiAdd("Barier", _httpcontext);


            var userInDB = await _blogPageContext.BlogUsers.FirstOrDefaultAsync(c => c.Email == blogUser.Email && c.Password == blogUser.Password);
            if (userInDB != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, blogUser.Email),
                    new Claim("role",userInDB.Role),
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(cookieString, claimsPrincipal, new AuthenticationProperties()
                {
                    IsPersistent = true,
                });

                return RedirectToAction("Index", "Home");
            }

            else return RedirectToAction("Registration");
        }

        public async Task<IActionResult> SignOutAuthorization()
        {
            await HttpContext.SignOutAsync(cookieString);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> AddAdmin()
        {

            return PartialView("AddAdmin");

        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> AddAdmin(BlogUser blogUser)
        {

            var userr = await _blogPageContext.BlogUsers.AddAsync(new BlogUser
            {
                Id = Guid.NewGuid().ToString(),
                Email = blogUser.Email,
                Password = blogUser.Password,
                Role = "User"
            });
            await _blogPageContext.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
