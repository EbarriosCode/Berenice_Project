using albumes.infrastructure.data.Respositories.Custom.Artists;
using albumes.models.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace albumes.application.Handlers.Artists
{
    public class ArtistsHandler : IArtistsHandler
    {
        private readonly IArtistsRepository _repository;
        public ArtistsHandler(IArtistsRepository repository) => this._repository = repository;

        public async Task<Artist[]> GetArtists()
        {
            var listOfArtists = Array.Empty<Artist>();

            try
            {
                listOfArtists = this._repository.Get(null, null, string.Empty).ToArray();
            }
            catch (Exception)
            {
                throw;
            }

            return await Task.FromResult(listOfArtists);
        }

        public async Task<Artist> GetArtist(int id)
        {
            Artist artist = null;

            try
            {
                var artists = this._repository.Get(x => x.ArtistID == id, null, string.Empty).ToArray();

                if (artists.Length > 0)
                    artist = artists[0];
            }
            catch (Exception)
            {
                throw;
            }

            return await Task.FromResult(artist);
        }

        public async Task<Artist> CreateArtistAsync(Artist artist)
        {
            Artist artistCreated = new();

            try
            {
                if (artist != null)
                    artistCreated = await this._repository.CreateAsync(artist);
            }
            catch (Exception)
            {
                throw;
            }

            return artistCreated;
        }

        public async Task<Artist> UpdateArtistAsync(Artist artist)
        {
            Artist artistUpdated = new();

            try
            {
                if (artist != null)
                    artistUpdated = await this._repository.UpdateAsync(artist, artist.ArtistID);
            }
            catch (Exception)
            {
                throw;
            }

            return artistUpdated;
        }

        public async Task<int> DeleteArtistAsync(Artist artist)
        {
            int deleted = 0;

            try
            {
                if (artist != null)
                    deleted = await this._repository.DeleteAsync(artist);
            }
            catch (Exception)
            {
                throw;
            }

            return deleted;
        }
    }
}
