using Microsoft.EntityFrameworkCore;

namespace Blog_Page.Models
{
    public class BlogPageContext : DbContext
    {

        public DbSet<Comment> Comments { get; set; } 
        public DbSet<BlogPost> BlogPosts { get; set;} 
        public DbSet<FavoritePost> FavoritePosts { get; set;}


        public BlogPageContext(DbContextOptions<BlogPageContext> options)
            : base(options)
        {

            //Database.EnsureDeleted();
            Database.EnsureCreated();


        }




    }
    
}
