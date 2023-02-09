
using Microsoft.AspNetCore.Identity;
namespace Blog_Page.Models
{
    public class BlogUser : IdentityUser    
    {

        public int Id { get; set; }
        public string? Email { get; set; }
        public sbyte? Password { get; set; }


    }
}
