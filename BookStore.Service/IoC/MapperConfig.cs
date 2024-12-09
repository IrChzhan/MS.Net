using BookStore.BL.Mapper;

namespace BookStore.Service.IoC;

public static class MapperConfig
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