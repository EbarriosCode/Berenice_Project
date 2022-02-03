using albumes.infrastructure.data.Respositories.Generic;
using albumes.models.Entities;

namespace albumes.infrastructure.data.Respositories.Custom.Artists
{
    public class ArtistsRepository : BaseRepository<Artist>, IArtistsRepository
    {
        public ArtistsRepository(IUnitOfWork _unitOfWork)
            : base(_unitOfWork)
        { }   
    }
}
