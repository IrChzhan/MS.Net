using BookStore.Service.IoC;
using BookStore.Service.Settings;

var builder = WebApplication.CreateBuilder(args);

SerilogConfig.ConfigureService(builder);
DbContextConfigurator.ConfigureService(builder);
MapperConfig.ConfigureServices(builder);
SwaggerConfig.ConfigureServices(builder.Services);
ServicesConfig.ConfigureServices(builder.Services);
builder.Services.AddControllers();

var app = builder.Build();

SerilogConfig.ConfigureApplication(app);
DbContextConfigurator.ConfigureApplication(app);
SwaggerConfig.ConfigureApplication(app);

app.UseHttpsRedirection();
app.MapControllers();
app.Run();