using BookStore.Service.IoC;

var builder = WebApplication.CreateBuilder(args);

SerilogConfig.ConfigureService(builder);
SwaggerConfig.ConfigureServices(builder.Services);
DbContextConfigurator.ConfigureService(builder);

var app = builder.Build();

SerilogConfig.ConfigureApplication(app);
SwaggerConfig.ConfigureApplication(app);
DbContextConfigurator.ConfigureApplication(app);
app.UseHttpsRedirection();
app.Run();