using albumes.infrastructure.data.Respositories.Generic;
using albumes.models.Entities;

namespace albumes.infrastructure.data.Respositories.Custom.Albumes
{
    public class AlbumesRepository : BaseRepository<Album>, IAlbumesRepository
    {
        public AlbumesRepository(IUnitOfWork _unitOfWork)
            : base(_unitOfWork)
        { }
    }
}
