
using NLog;
using NLog.Web; 
using NLogSample;

var builder = WebApplication.CreateBuilder(args);
var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Error("Logger test"); 

try
{
    #region Service Scope

    builder.AddNLog();

    builder.Services.AddControllers();           

    //register other services here
    #endregion



    #region App Scope

    var app = builder.Build();
    
    //register other middlewares here

    app.UseRouting();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });

    app.Run();

    #endregion
}
catch (Exception ex)
{
    // NLog: catch setup errors
    logger.Error(ex, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}
