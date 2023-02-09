
using Microsoft.AspNetCore.Identity;
namespace Blog_Page.Models
{
    public class BlogUser
    {

        public int UserId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }



        public ICollection<BlogPost> FavoritePosts { get; set; }

        public BlogUser()
        {
            FavoritePosts = new List<BlogPost>();   
        }


    }
}
