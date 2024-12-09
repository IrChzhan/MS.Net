using BookStore.Service.IoC;
using BookStore.Service.Settings;

namespace BookStore.Service.DI;

public class ApplicationConfigurator
{
    public static void ConfigureServices(WebApplicationBuilder builder, BookStoreSettings bookStoreSettings)
    {
        DbContextConfigurator.ConfigureService(builder); 
        SerilogConfig.ConfigureService(builder);
        SwaggerConfig.ConfigureServices(builder.Services);
        MapperConfig.ConfigureServices(builder);
    }
}