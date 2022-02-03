using albumes.infrastructure.data.Respositories.Custom.Albumes;
using albumes.models.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace albumes.application.Handlers.Albumes
{
    public class AlbumesHandler : IAlbumesHandler
    {
        private readonly IAlbumesRepository _repository;
        public AlbumesHandler(IAlbumesRepository repository) => this._repository = repository;

        public async Task<Album[]> GetAlbumes()
        {
            var listOfAlbumes = Array.Empty<Album>();

            try
            {
                listOfAlbumes = this._repository.Get(null, null, "Artist").ToArray();
            }
            catch (Exception)
            {
                throw;
            }

            return await Task.FromResult(listOfAlbumes);
        }

        public async Task<Album> GetAlbumById(int id)
        {
            Album album = null;            

            try
            {
                var albumes = this._repository.Get(x => x.AlbumID == id, null, "Artist").ToArray();

                if (albumes.Length > 0)
                    album = albumes[0];
            }
            catch (Exception)
            {
                throw;
            }

            return await Task.FromResult(album);
        }

        public async Task<Album> CreateAlbumAsync(Album album)
        {
            Album albumCreated = new();

            try
            {
                if (album != null)
                    albumCreated = await this._repository.CreateAsync(album);
            }
            catch (Exception)
            {
                throw;
            }

            return albumCreated;
        }

        public async Task<Album> UpdateAlbumAsync(Album album)
        {
            Album albumUpdated = new();

            try
            {
                if (album != null)
                    albumUpdated = await this._repository.UpdateAsync(album, album.AlbumID);
            }
            catch (Exception)
            {
                throw;
            }

            return albumUpdated;
        }

        public async Task<int> DeleteAlbumAsync(Album album)
        {
            int deleted = 0;

            try
            {
                if (album != null)
                    deleted = await this._repository.DeleteAsync(album);
            }
            catch (Exception)
            {
                throw;
            }

            return deleted;
        }            
    }
}
