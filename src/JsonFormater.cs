using JsonStringFormatter.Implementation;

namespace JsonStringFormatter;
public static class JsonFormater
{
    /// <summary>
    /// Extension function for JSON string which returns a formatted string to print in console or to fie
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string? FormatJsonString(this string? str) => FormateJsonStringImpl.Impl(str);

    /// <summary>
    /// Prints a pretty JSON to console
    /// </summary>
    /// <param name="str"></param>
    public static void PrintJsonToConsole(this string? str) => PrintJsonToConsoleImpl.Impl(str);
}