using Blog_Page.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
namespace Blog_Page.ViewComponent
{
    using Microsoft.AspNetCore.Mvc;
    public class BlogPostGeneratorViewComponent : ViewComponent
    {
        private readonly BlogPageContext _blogPageContext;

        public BlogPostGeneratorViewComponent(BlogPageContext blogPageContext)
        {
            _blogPageContext = blogPageContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("PostCard" , await _blogPageContext.BlogPosts.ToListAsync() );
        }

    }
}
