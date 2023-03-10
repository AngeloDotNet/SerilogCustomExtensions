namespace SerilogCustomExtensions.Service;

public interface IUtilService
{
    /// <summary>
    /// Abstraction of the objectResult of the statusCode
    /// </summary>
    /// <param name="message"></param>
    /// <param name="statusCode"></param>
    /// <param name="typeCode"></param>
    /// <param name="httpContext"></param>
    /// <returns></returns>
    ErrorResponse ManageError(string message, int statusCode, int typeCode, HttpContext httpContext);

    /// <summary>
    /// Saving logs of type information
    /// </summary>
    /// <param name="message"></param>
    void SaveLogInformation(string message);
}