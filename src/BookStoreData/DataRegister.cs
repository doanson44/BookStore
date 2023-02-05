using BookStoreData.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookStoreData
{
    public static class DataRegister
    {
        public static void Initialize(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<BookStoreContext>((provider, options) =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                var connectionString = configuration.GetConnectionString("BookStoreConnection");

                options.UseSqlServer(connectionString);
            });

            PostInitialize(serviceCollection);
        }

        private static void PostInitialize(IServiceCollection serviceCollection)
        {
            var sp = serviceCollection.BuildServiceProvider();
            using var serviceScope = sp.CreateScope();
            using var dbContext = serviceScope.ServiceProvider.GetRequiredService<BookStoreContext>();

            dbContext.Database.EnsureCreated();
            try
            {
                dbContext.Database.Migrate();
            }
            catch
            {
                // Do nothing
            }
        }
    }
}
