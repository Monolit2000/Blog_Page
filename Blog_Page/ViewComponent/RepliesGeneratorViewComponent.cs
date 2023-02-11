
using Blog_Page.Models;
using Blog_Page.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
namespace Blog_Page.ViewComponent
{
    using Microsoft.AspNetCore.Mvc;
    public class RepliesGeneratorViewComponent : ViewComponent
    {
        private readonly BlogPageContext _blogPageContext;

        public RepliesGeneratorViewComponent(BlogPageContext blogPageContext)
        {
            _blogPageContext = blogPageContext;
        }

        public async Task<IViewComponentResult> InvokeAsync(string repliesId)
        {

            var comments = await _blogPageContext.Comments.Where(c => c.repliesId == repliesId).ToListAsync();

            return View("CommentList", comments);
        }

    }
}