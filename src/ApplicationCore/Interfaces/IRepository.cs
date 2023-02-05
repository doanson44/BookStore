using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.BookStore.ApplicationCore.Interfaces;

public interface IRepository<TEntity, TDbContext> : IRepositoryBase<TEntity> where TEntity : class where TDbContext : DbContext
{
}
