using Microsoft.EntityFrameworkCore;

namespace MakaleProject.Models.Context
{
    public class ArticleDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ArticleDetails> ArticleDetails { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Article.db");
        }
        
    }
}
