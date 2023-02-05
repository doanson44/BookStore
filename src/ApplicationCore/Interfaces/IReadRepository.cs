using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.BookStore.ApplicationCore.Interfaces;

public interface IReadRepository<TEntity, TDbContext> : IReadRepositoryBase<TEntity> where TEntity : class where TDbContext : DbContext
{
}
