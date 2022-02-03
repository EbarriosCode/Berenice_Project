using albumes.models.Entities;
using System.Threading.Tasks;

namespace albumes.application.Handlers.Artists
{
    public interface IArtistsHandler
    {
        Task<Artist[]> GetArtists();
        Task<Artist> GetArtist(int id);
        Task<Artist> CreateArtistAsync(Artist artist);
        Task<Artist> UpdateArtistAsync(Artist artist);
        Task<int> DeleteArtistAsync(Artist artist);
    }
}
