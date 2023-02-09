

namespace Blog_Page.Models
{
    public class BlogPost
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
