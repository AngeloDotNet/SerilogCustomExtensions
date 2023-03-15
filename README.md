# Serilog custom extensions

If you like this repository, please drop a :star: on Github!


## Installation

The library is available on [NuGet](https://www.nuget.org/packages/SerilogCustomExtensions) or run the following command in the .NET CLI:

```bash
dotnet add package SerilogCustomExtensions
```


## Configuration to add to the appsettings.json file

```json
"Serilog": {
  "MinimumLevel": "Warning",
  "WriteTo": [
    {
      "Name": "Console",
      "Args": {
        "outputTemplate": "{Timestamp:HH:mm:ss}\t{Level:u3}\t{SourceContext}\t{Message}{NewLine}{Exception}"
      }
    },
    {
      "Name": "File",
      "Args": {
        "path": "Logs/log.txt",
        "rollingInterval": "Day",
        "retainedFileCountLimit": 14,
        "restrictedToMinimumLevel": "Warning",
        "formatter": "Serilog.Formatting.Json.JsonFormatter, Serilog"
      }
    }
  ]
}
```


## Registering services at Startup

```csharp
public Startup(IConfiguration configuration)
{
  Configuration = configuration;
}

public IConfiguration Configuration { get; }
	
public void ConfigureServices(IServiceCollection services)
{
    services.AddSerilogServices();
}

//OMISSIS

public void Configure(WebApplication app)
{
    app.AddSerilogConfigureServices();
}
```


## Registering services at Program

```csharp
public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.AddSerilogOptionsBuilder();

        Startup startup = new(builder.Configuration);

        //OMISSIS
    }
```


## Example of use in a web api controller

```csharp
[ApiController]
[Route("api/[controller]")]
public class EmailController : ControllerBase
{
  private readonly ILoggerService loggerService;

  public EmailController(ILoggerService loggerService)
  {
    this.loggerService = loggerService;
  }
  
  //OMISSIS
}
```