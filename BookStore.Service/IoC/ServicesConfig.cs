using AutoMapper;
using BookStore.BL.Users.Manager;
using BookStore.BL.Users.Provider;
using BookStore.DataAccess;
using BookStore.DataAccess.Entities;
using BookStore.Repository;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Service.IoC;

 public static class ServicesConfig
 {
     public static void ConfigureServices(IServiceCollection services)
     {
         services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
         services.AddScoped<IRepository<User>>(x => 
             new Repository<User>(x.GetRequiredService<IDbContextFactory<BookStoreDbContext>>()));
         services.AddScoped<IUsersManager>(x => new UsersManager(
             x.GetRequiredService<IRepository<User>>(),
                 x.GetRequiredService<IMapper>()));
         services.AddScoped<IUsersProvider>(x => new UsersProvider(
             x.GetRequiredService<IRepository<User>>(),
             x.GetRequiredService<IMapper>()));
     }
 }