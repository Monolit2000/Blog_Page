namespace Blog_Page.Models
{
    public class FavoritePost
    {

        public int Id { get; set; }
        public int BlogPostId { get; set; }
        public string UserId { get; set; }

        public BlogPost BlogPost { get; set; }
        //public ApplicationUser User { get; set; }

    }
}
