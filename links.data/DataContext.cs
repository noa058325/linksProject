using Microsoft.EntityFrameworkCore;
using links.Entities;

namespace links.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Web> Webs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Recommend> Recommends { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Links_db");
        }
    }
}
