namespace SerilogCustomExtensions.Service;

public interface IUtilService
{
    ErrorResponse ManageError(string message, int statusCode, int typeCode, HttpContext httpContext);
    void SaveLogInformation(string message);
}