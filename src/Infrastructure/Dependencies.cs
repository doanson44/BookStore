using BookStoreData.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoData.Data;

namespace Microsoft.BookStore.Infrastructure;

public static class Dependencies
{
    public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {
        var useOnlyInMemoryDatabase = false;
        if (configuration["UseOnlyInMemoryDatabase"] != null)
        {
            useOnlyInMemoryDatabase = bool.Parse(configuration["UseOnlyInMemoryDatabase"]);
        }

        if (useOnlyInMemoryDatabase)
        {
            services.AddDbContext<BookStoreContext>(b =>
                b.UseInMemoryDatabase("BookStore"));

            services.AddDbContext<TodoListDbContext>(b =>
                b.UseInMemoryDatabase("TodoList"));
        }
        else
        {
            BookStoreData.DataRegister.Initialize(services);
            ToDoData.DataRegister.Initialize(services);
        }
    }
}
