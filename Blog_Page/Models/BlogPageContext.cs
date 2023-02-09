using Microsoft.EntityFrameworkCore;

namespace Blog_Page.Models
{
    public class BlogPageContext : DbContext
    {

        public DbSet<Comment> Comments { get; set; } 
        public DbSet<BlogCard> BlogCards { get; set;} 


        public BlogPageContext(DbContextOptions<BlogPageContext> options)
            : base(options)
        {

            //Database.EnsureDeleted();
            Database.EnsureCreated();


        }




    }
    
}
