using BookStore.BL.Mapper;

namespace BookStore.Service.IoC;

public static class MapperConfig
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile<UsersBLProfile>();
            config.AddProfile<UserMappingProfile>(); //Добавьте эту строку
        });
    }
}