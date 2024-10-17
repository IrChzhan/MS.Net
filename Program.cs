using MS.Net.Service.IoC;

var builder = WebApplication.CreateBuilder(args);

SerilogConfig.ConfigureService(builder);
SwaggerConfig.ConfigureServices(builder.Services);

var app = builder.Build();

SerilogConfig.ConfigureApplication(app);
SwaggerConfig.ConfigureApplication(app);

app.UseHttpsRedirection();
app.Run();
