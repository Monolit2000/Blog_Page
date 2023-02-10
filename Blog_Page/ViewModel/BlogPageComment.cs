using Blog_Page.Models;
namespace Blog_Page.ViewModel
{
    public class BlogPageComment
    {
        public BlogPost blogPost { get; set; } 
        public IEnumerable<Comment> comments { get; set; } = new List<Comment>();



    }
}
