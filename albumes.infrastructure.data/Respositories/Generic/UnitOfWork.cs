using albumes.infrastructure.data.DataContext;

namespace albumes.infrastructure.data.Respositories.Generic
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext Context { get; }

        public UnitOfWork(ApplicationDbContext context) => Context = context;

        public void Commit() => Context.SaveChanges();

        public void Dispose() => Context.Dispose();
    }
}
