namespace SerilogCustomExtensions.Extentions;

public static class DependencyInjection
{
    public static IServiceCollection AddBusinessLayerServices(this IServiceCollection services)
    {
        services
            .AddTransient<IUtilService, UtilService>();

        return services;
    }

    public static WebApplication AddApplicationServices(this WebApplication application)
    {
        application.UseSerilogRequestLogging(options =>
        {
            options.IncludeQueryInRequestPath = true;
        });

        return application;
    }

    public static WebApplicationBuilder AddOptionsBuilder(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
        {
            loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration);
        });

        return builder;
    }
}