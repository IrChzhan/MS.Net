 using AutoMapper;
 using BookStore.BL.Users.Manager;
 using BookStore.BL.Users.Provider;
 using BookStore.DataAccess;
 using BookStore.Repository;
 using BookStore.DataAccess.Entities;
 using Microsoft.EntityFrameworkCore;

 namespace BookStore.Service.IoC;

 public class ServicesConfig
 {
     public static void ConfigureServices(IServiceCollection services)
     {
         services.AddEndpointsApiExplorer();
         services.AddSwaggerGen();
     }
    
     public static void ConfigureApplication(IApplicationBuilder app)
     {
         app.UseSwagger();
         app.UseSwaggerUI();
     }
 }