using Microsoft.EntityFrameworkCore;

namespace MvcWebProje.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<iletisim> iletisims { get; set; }
    }
}
