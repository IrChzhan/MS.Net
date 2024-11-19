using AutoMapper;
using BookStore.BL.Users.Manager;
using BookStore.BL.Users.Provider;
using BookStore.DataAccess;
using BookStore.Repository;
using BookStore.DataAccess.Entities;
using BookStore.Service.Settings;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Service.IoC;

public class ServicesConfig
{
    public static void ConfigureServices(IServiceCollection services, BookStoreSettings settings)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IRepository<User>>(x =>
            new Repository<User>(x.GetRequiredService<IDbContextFactory<BookStoreDbContext>>()));
        services.AddScoped<IUsersProvider>(x => 
            new UsersProvider(x.GetRequiredService<IRepository<User>>(), 
                x.GetRequiredService<IMapper>()));
        
    }
}