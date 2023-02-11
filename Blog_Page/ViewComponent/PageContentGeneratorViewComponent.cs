
using Blog_Page.Models;
using Blog_Page.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
namespace Blog_Page.ViewComponent
{
    using Microsoft.AspNetCore.Mvc;
    public class PageContentGeneratorViewComponent : ViewComponent
    {
        private readonly BlogPageContext _blogPageContext;

        public PageContentGeneratorViewComponent(BlogPageContext blogPageContext)
        {
            _blogPageContext = blogPageContext;
        }

        public async Task<IViewComponentResult> InvokeAsync(string postid)
        {
            
            var comments = await _blogPageContext.Comments.Where(c => c.PostId == postid).ToListAsync();
            //foreach (var comment in comments)
            //{

            //}
            //var reqestComent = await _blogPageContext.Comments.Where(c => )
            //var mainmodl = new MainComment
            //{
            //    coments = comments,
            //};

            return View("CommentList", comments);
        }

    }
}