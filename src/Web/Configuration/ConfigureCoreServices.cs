using BookStoreData.Interfaces;
using BookStoreData.Queries;
using Microsoft.BookStore.ApplicationCore.Interfaces;
using Microsoft.BookStore.ApplicationCore.Services;
using Microsoft.BookStore.Infrastructure.Data;
using Microsoft.BookStore.Infrastructure.Logging;
using Microsoft.BookStore.Infrastructure.Services;

namespace Microsoft.BookStore.Web.Configuration;

public static class ConfigureCoreServices
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped(typeof(IReadRepository<,>), typeof(EfRepository<,>));
        services.AddScoped(typeof(IRepository<,>), typeof(EfRepository<,>));

        services.AddScoped<IBookQueryService, BookQueryService>();
        services.AddSingleton<IUriComposer>(new UriComposer(configuration.Get<BookSettings>()));
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        services.AddTransient<IEmailSender, EmailSender>();

        return services;
    }
}
