namespace SerilogCustomExtensions.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddSerilogServices(this IServiceCollection services)
    {
        services.AddTransient<ILoggerService, LoggerService>();

        return services;
    }

    public static WebApplication AddSerilogConfigureServices(this WebApplication application)
    {
        application.UseSerilogRequestLogging(options =>
        {
            options.IncludeQueryInRequestPath = true;
        });

        return application;
    }

    public static WebApplicationBuilder AddSerilogOptionsBuilder(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
        {
            loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration);
        });

        return builder;
    }
}