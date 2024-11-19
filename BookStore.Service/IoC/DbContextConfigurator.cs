using BookStore.DataAccess;
using BookStore.Service.Settings;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Service.IoC;

public static class DbContextConfigurator
{
    public static void ConfigureService(WebApplicationBuilder builder)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .Build();
        string connectionString = configuration.GetValue<string>("BookStoreDbContext");

        builder.Services.AddDbContextFactory<BookStoreDbContext>(
            options => { options.UseNpgsql(connectionString); },
            ServiceLifetime.Scoped
        );
    }
    
    public static void ConfigureApplication(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<BookStoreDbContext>>();
        using var context = contextFactory.CreateDbContext();
        context.Database.Migrate();
    }

    public static void ConfigureService(IServiceCollection builderServices, BookStoreSettings settings)
    {
        var connectionString = settings.BookStoreDBContextConnectionString;
        builderServices.AddDbContextFactory<BookStoreDbContext>(
            options => { options.UseNpgsql(connectionString); },
            ServiceLifetime.Scoped);
    }
}