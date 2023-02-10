
using System.ComponentModel.DataAnnotations;

namespace Blog_Page.Models
{
    public class Comment
    {
        [Key]
        public string Id { get; set; }
        public string PostId { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }   
       // public BlogPost BlogPost { get; set; }
        public DateTime Date { get; set; }

    }
}
