using Microsoft.BookStore.Web.Interfaces;
using Microsoft.BookStore.Web.Services;

namespace Microsoft.BookStore.Web.Configuration;

public static class ConfigureWebServices
{
    public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<BookViewModelService>();
        services.AddScoped<IBookViewModelService, CachedBookViewModelService>();

        return services;
    }
}
