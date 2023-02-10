using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Blog_Page.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Html;

namespace WebApplication1.ViewComponent
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;


    public class AutorizationViewComponent : ViewComponent
    {
        BlogPageContext _blogPageContext;

        public AutorizationViewComponent(BlogPageContext blogPageContext)
        {
            _blogPageContext = blogPageContext;

        }
        //[Authorize(Policy = "Admin")]

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = User.Identity;
            var name = user.Name;
            var AuthenticationType = user.AuthenticationType;
            var role = HttpContext.User.FindFirst("role");
            var SignOut = new HtmlContentViewComponentResult(new HtmlString($"<a class=\"navitem\" href=\"/Account/SignOutAuthorization\"> {name}-{role} SingOut </a>"));
            var SingIn = new HtmlContentViewComponentResult(new HtmlString($"<a class=\"navitem\" href=\"/Account/SignInAuthorization\">Login</a>  <a class=\"navitem\" href=\"/Account/Registration\">Registration</a>"));

            return user.IsAuthenticated ? SignOut : SingIn;
        }
    }
}