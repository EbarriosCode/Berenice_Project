using albumes.infrastructure.data.DataContext;
using System;

namespace albumes.infrastructure.data.Respositories.Generic
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationDbContext Context { get; }
        void Commit();
    }
}
