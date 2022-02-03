using albumes.models.Entities;
using System.Threading.Tasks;

namespace albumes.application.Handlers.Albumes
{
    public interface IAlbumesHandler
    {
        Task<Album[]> GetAlbumes();
        Task<Album> GetAlbumById(int id);
        Task<Album> CreateAlbumAsync(Album album);
        Task<Album> UpdateAlbumAsync(Album album);
        Task<int> DeleteAlbumAsync(Album album);
    }
}
