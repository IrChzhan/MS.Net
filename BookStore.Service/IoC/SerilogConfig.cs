using Serilog;

namespace BookStore.Service.IoC;

public static class SerilogConfig
{
    public static void ConfigureService(WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((context, loggerConfiguration) =>
        {
            loggerConfiguration
                .Enrich.WithCorrelationId()
                .ReadFrom.Configuration(context.Configuration);
        });

        builder.Services.AddHttpContextAccessor();
    }

    public static void ConfigureApplication(IApplicationBuilder app)
    {
        app.UseSerilogRequestLogging();
    }
}