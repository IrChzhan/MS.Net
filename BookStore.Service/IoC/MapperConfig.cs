﻿using BookStore.BL.Mapper;

namespace BookStore.Service.IoC;

public class MapperConfig
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile<UsersBLProfile>();
        });
    }
}