using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.BookStore.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.BookStore.Infrastructure.Data;

public class EfRepository<TEntity, TDbContext> : RepositoryBase<TEntity>, IReadRepository<TEntity, TDbContext>, IRepository<TEntity, TDbContext> where TEntity : class where TDbContext : DbContext
{
    public EfRepository(TDbContext dbContext) : base(dbContext)
    {
    }
}
