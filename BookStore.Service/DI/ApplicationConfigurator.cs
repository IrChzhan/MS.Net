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
        AuthorizationConfig.ConfigureServices(builder.Services, bookStoreSettings);
    }
    
    public static void ConfigureApplication(WebApplication app)
    {
        SerilogConfig.ConfigureApplication(app);
        SwaggerConfig.ConfigureApplication(app);
        DbContextConfigurator.ConfigureApplication(app);
        AuthorizationConfig.ConfigureApplication(app);
        
        app.UseHttpsRedirection();
        app.MapControllers();
    }
}