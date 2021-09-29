using Entities;
using Microsoft.EntityFrameworkCore;
using Type = Entities.Type;

namespace DataAccess
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Type> Types { get; set; }
    }
}
