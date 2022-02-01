using albumes.infrastructure.data.Respositories.Custom.Albumes;
using albumes.infrastructure.data.Respositories.Custom.Artists;
using albumes.infrastructure.data.Respositories.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace albumes.middleware.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            // Inject the service generic repository
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            
            // Inject repositories
            services.AddScoped<IAlbumesRepository, AlbumesRepository>();
            services.AddScoped<IArtistsRepository, ArtistsRepository>();

            return services;
        }
    }
}
