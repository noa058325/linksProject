using Microsoft.EntityFrameworkCore;
using links.Entities;
using Microsoft.Extensions.Configuration;

namespace links.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Web> Webs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Recommend> Recommends { get; set; }
        private readonly IConfiguration _configuration;
        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["ConnectionStrings"]);
        }
    }
}
