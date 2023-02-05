using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoData.Data;

namespace ToDoData
{
    public static class DataRegister
    {
        public static void Initialize(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<TodoListDbContext>((provider, options) =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                var connectionString = configuration.GetConnectionString("TodoListDbConnection");

                options.UseSqlServer(connectionString);
            });

            PostInitialize(serviceCollection);
        }

        private static void PostInitialize(IServiceCollection serviceCollection)
        {
            var sp = serviceCollection.BuildServiceProvider();
            using var serviceScope = sp.CreateScope();
            using var dbContext = serviceScope.ServiceProvider.GetRequiredService<TodoListDbContext>();

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
