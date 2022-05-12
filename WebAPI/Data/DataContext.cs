using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { 
            
        }

        public DbSet<AnimalType> AnimalType { get; set; }

        public DbSet<Animal> Animals { get; set; }

        public DbSet<Enclos> Enclos { get; set; }

        public DbSet<FavoriteFood> FavoriteFood { get; set; }
    }
}
