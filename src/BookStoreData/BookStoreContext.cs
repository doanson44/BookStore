using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BookStoreData.Data
{
    public partial class BookStoreContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer("Data Source=.;Initial Catalog=BookStore;Integrated Security=True;TrustServerCertificate=True");
            }
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
