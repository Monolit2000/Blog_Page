using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Blog_Page.Models;
using Microsoft.Data;

namespace Blog_Page.Controllers
{
    public class BlogPostController : Controller
    {
        private readonly BlogPageContext _blogPageContext;
        public BlogPostController(BlogPageContext blogPageContext)
        {
            _blogPageContext = blogPageContext;
        }

        // GET: BlogPostController

        [HttpGet]
        public async Task<IActionResult> CreatePost()
        {
             return PartialView("CreatePostView");
        }

        [HttpPost]
        public  async Task<IActionResult> CreatePost( string title, string content)
        {
            await _blogPageContext.BlogPosts.AddAsync(new BlogPost
            {
                Id = Guid.NewGuid().ToString(),
                Title = title,
                Content = content,
                Date = DateTime.Now,
                Author = "Ded",
            });
            await _blogPageContext.SaveChangesAsync();
            return RedirectToAction("Index","Home");
        }



    }
}

  
