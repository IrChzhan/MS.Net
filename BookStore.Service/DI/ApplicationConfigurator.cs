using BookStore.Service.IoC;
using BookStore.Service.Settings;

namespace BookStore.Service.DI;

public class ApplicationConfigurator
{
    public static void ConfigureServices(WebApplicationBuilder builder, BookStoreSettings settings)
    {
        DbContextConfigurator.ConfigureService(builder.Services, settings);
        SerilogConfig.ConfigureService(builder);
        SwaggerConfig.ConfigureServices(builder.Services);
        MapperConfig.ConfigureServices(builder.Services);
        ServicesConfig.ConfigureServices(builder.Services, settings);
        builder.Services.AddControllers();
    }
    
    public static void ConfigureApplication(WebApplication app)
    {
        SerilogConfig.ConfigureApplication(app);
        SwaggerConfig.ConfigureApplication(app);
        DbContextConfigurator.ConfigureApplication(app);
        app.MapControllers();
    }
}