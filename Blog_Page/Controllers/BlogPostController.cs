using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Blog_Page.Models;
using Microsoft.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

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
        //[Authorize(Policy = "Admin")]
        public async Task<IActionResult> CreatePost(string title, string content)
        {
            await _blogPageContext.BlogPosts.AddAsync(new BlogPost
            {
                Id = Guid.NewGuid().ToString(),
                Title = title,
                Content = content,
                Date = DateTime.Now,
                Author = User.Identity.Name,
                ImageUrl = "///"
            });
            await _blogPageContext.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> PostPage(string Id)
        {
            var Post = _blogPageContext.BlogPosts.FirstOrDefault(c => c.Id == Id);
            Post.LikeCount++;
            return PartialView("PostPage", Post);
        }

        [HttpPost]
        public async Task<IActionResult> LikeSystem(string Id)
        {
            //var Post = new BlogPost
            var Post = await _blogPageContext.BlogPosts.SingleOrDefaultAsync(c => c.Id == Id);

            var favpost = await _blogPageContext.FavoritePosts.FirstOrDefaultAsync(
                f => f.UserId == User.Identity.Name &&
                f.BlogPostId == Id);
            if (favpost == null)
            {
                await _blogPageContext.FavoritePosts.AddAsync(new FavoritePost
                {

                    Id = Post.Id,
                    BlogPostId = Id,
                    UserId = User.Identity.Name


                });
            }
            if (favpost == null)
            {
                Post.LikeCount++;
            }
            if (favpost != null)
            {
                _blogPageContext.FavoritePosts.Remove(favpost);
                Post.LikeCount--;
            }
            await _blogPageContext.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public async Task<IActionResult> CommentSystem(string Id)
        {

            var newComment = new Comment
            {
                Id = Guid.NewGuid().ToString(),

            };
            await _blogPageContext.Comments.AddAsync( new  );

            var Post = _blogPageContext.BlogPosts.FirstOrDefault(c => c.Id == Id);
            return PartialView("PostPage", Post);

        }
    }
}

  
