
namespace Blog_Page.Models
{
    public class Comment
    {
        public string Id { get; set; }
        public string PostId { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }   
        public DateTime Date { get; set; }

    }
}
