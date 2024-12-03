using BookStore.Service.IoC;

var builder = WebApplication.CreateBuilder(args);

SerilogConfig.ConfigureService(builder);
DbContextConfigurator.ConfigureService(builder);
MapperConfig.ConfigureServices(builder.Services);
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