using Blog_Page.Models;

namespace Blog_Page.ViewModel
{
    public class MainComment
    {
        public string Id { get; set; }
        public string PostId { get; set; }
       // public IEnumerable<Comment> Replies { get; set; } = new List<Comment>();
        public IEnumerable<Comment> coments { get; set; } = new List<Comment>();
    }
}
