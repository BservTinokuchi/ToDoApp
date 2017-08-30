using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;


using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;


namespace MultiChannelToDo
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            TelemetryConfiguration.Active.TelemetryInitializers.Add(new ConfigInitializer());


            GlobalConfiguration.Configure(WebApiConfig.Register);

            var config = GlobalConfiguration.Configuration.Formatters;
            config.Clear();
            config.Add(new JsonMediaTypeFormatter());
        }
    }


    // Begin new code
    public class ConfigInitializer
    : ITelemetryInitializer
    {
        void ITelemetryInitializer.Initialize(ITelemetry telemetry)
        {
            telemetry.Context.Properties["Environment"] = System.Configuration.ConfigurationManager.AppSettings["environment"];
        }
    }
    // End new code



}
