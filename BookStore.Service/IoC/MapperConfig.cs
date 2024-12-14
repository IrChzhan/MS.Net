using BookStore.BL.Mapper;

namespace BookStore.Service.IoC;

public class MapperConfig(Func<object, object> func)
{
    public static void ConfigureServices(WebApplicationBuilder builder)
    {
        var services = builder.Services;
        services.AddAutoMapper(config =>
        {
            config.AddProfile<UsersBLProfile>();
            config.AddProfile<UserMappingProfile>();
        });
    }
}