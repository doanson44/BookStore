using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ToDoData.Data;
public partial class TodoListDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer("Data Source=.;Initial Catalog=TodoListDb;Integrated Security=True;TrustServerCertificate=True");
        }
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
