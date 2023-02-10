using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Blog_Page.Models
{
    public class BlogUser
    {
        [Key]
        public string? Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        



        public ICollection<BlogPost> FavoritePosts { get; set; }

        //public BlogUser()
        //{
        //    Id = Guid.NewGuid().ToString();   
        //}


    }
}
