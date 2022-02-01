using albumes.models.Entities;
using Microsoft.EntityFrameworkCore;

namespace albumes.infrastructure.data.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Album> Albumes { get; set; }
        public DbSet<Artist> Artists { get; set; }
    }
}
