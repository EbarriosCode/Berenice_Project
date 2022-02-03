using albumes.infrastructure.data.DataContext;
using albumes.models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace albumes.infrastructure.data.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var _context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                #region Adding-Artists
                if (_context.Artists.Any())
                    return;

                _context.Artists.AddRange(
                    new Artist { Name = "Ricardo Arjona"},
                    new Artist { Name = "Frank Sinatra" },
                    new Artist { Name = "Luis Miguel" }
                );

                _context.SaveChanges();
                #endregion Adding-Artists

                #region Adding-Albumes
                if (_context.Albumes.Any())
                    return;

                _context.Albumes.AddRange(
                    new Album
                    {
                        ArtistID = _context.Artists.Where(x => x.Name.Contains("Ricardo Arjona")).FirstOrDefault().ArtistID,
                        Title = "Santo Pecado",
                        Price = 125.00,
                        Date = new DateTime(2002, 11, 19),
                        AvailableToPurchase = false
                    },
                    new Album
                    {
                        ArtistID = _context.Artists.Where(x => x.Name.Contains("Ricardo Arjona")).FirstOrDefault().ArtistID,
                        Title = "Circo Soledad",
                        Price = 155.00,
                        Date = new DateTime(2017, 4, 21),
                        AvailableToPurchase = true
                    },
                    new Album
                    {
                        ArtistID = _context.Artists.Where(x => x.Name.Contains("Frank Sinatra")).FirstOrDefault().ArtistID,
                        Title = "My Way",
                        Price = 205.00,
                        Date = new DateTime(1969, 5, 2),
                        AvailableToPurchase = true
                    },
                    new Album
                    {
                        ArtistID = _context.Artists.Where(x => x.Name.Contains("Luis Miguel")).FirstOrDefault().ArtistID,
                        Title = "Romances",
                        Price = 145.00,
                        Date = new DateTime(1997, 8, 12),
                        AvailableToPurchase = true
                    }
                );

                _context.SaveChanges();
                #endregion Adding-Albumes
            }
        }
    }
}
