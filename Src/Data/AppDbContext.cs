using catedra1.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace catedra1.Src.Data
{
    public class AppDbContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<User> Users {get; set; } = null!;
    }
}