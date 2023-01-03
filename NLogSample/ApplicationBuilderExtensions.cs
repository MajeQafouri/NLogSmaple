

using NLog.Web;

namespace NLogSample;
public static class ApplicationBuilderExtensions
{
    public static void AddNLog(this WebApplicationBuilder builder)
    {
        // NLog: Setup NLog for Dependency injection
        builder.Logging.ClearProviders();
        builder.Logging.SetMinimumLevel(LogLevel.Error);
        builder.Host.UseNLog();
    }


    // add other extension here
}