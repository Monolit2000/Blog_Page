using System.ComponentModel.DataAnnotations;

namespace Blog_Page.Models
{
    public class FavoritePost
    {
        [Key]
        public string Id { get; set; }
        public string? BlogPostId { get; set; }
        public string? UserId { get; set; }
        public BlogPost? BlogPost { get; set; }
        //public ApplicationUser User { get; set; }

    }
}
