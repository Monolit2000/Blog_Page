using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Blog_Page.Models;
using Microsoft.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Blog_Page.ViewModel;

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
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> CreatePost()
        {
            return PartialView("CreatePostView");
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
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

        [HttpGet]
        public async Task<IActionResult> PostPage(string Id)
        {
            var Post = await _blogPageContext.BlogPosts.FirstOrDefaultAsync(c => c.Id == Id);
            var comments = await _blogPageContext.Comments.Where(c => c.PostId == Id).ToListAsync();
            BlogPageComment blogPageComment = new BlogPageComment
            {

                blogPost = Post,
                comments = comments

            };

            return PartialView("PostPage", blogPageComment);
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
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

                    Id = Guid.NewGuid().ToString(),
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
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> PostPage(string Id, string Text)
        {

            


            var Post = _blogPageContext.BlogPosts.FirstOrDefault(c => c.Id == Id);
            if (Post != null)
            {


                var newComment = new Comment
                {
                    Id = Guid.NewGuid().ToString(),
                    PostId = Id,
                    Author = User.Identity.Name,
                    Text = Text,
                    Date = DateTime.Now
                };

                await _blogPageContext.Comments.AddAsync(newComment);

                //Post.Comments.Add(newComment);
                
            }

             var comments = await _blogPageContext.Comments.Where(c => c.PostId == Id).ToListAsync();

            await _blogPageContext.SaveChangesAsync();

            BlogPageComment blogPageComment = new BlogPageComment
            {

                blogPost = Post,
                comments = comments

            };

            foreach(var item in comments)
            {
                Console.WriteLine(item.Text);
            }


            return PartialView("PostPage", blogPageComment);
        }
    }
}

  
