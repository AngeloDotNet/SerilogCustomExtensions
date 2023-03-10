namespace SerilogCustomExtensions.Service;

public class UtilService : IUtilService
{
    private List<string> errorList = new();

    private readonly ILogger<UtilService> logger;

    public UtilService(ILogger<UtilService> logger)
    {
        this.logger = logger;
    }

    public ErrorResponse ManageError(string message, int statusCode, int typeCode, HttpContext httpContext)
    {
        logger.LogWarning(message);

        errorList.Clear();
        errorList.Add(message);

        return new(statusCode, $"https://httpstatuses.com/{statusCode}", typeCode, httpContext.Request.Path, errorList);
    }

    public void SaveLogInformation(string message)
    {
        logger.LogInformation(message);
    }

    public void SaveLogWarning(string message)
    {
        logger.LogWarning(message);
    }
}