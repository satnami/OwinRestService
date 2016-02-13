using System;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Owin;

namespace RestOwin.Server
{
    public class Startup
    {
        //  Hack from http://stackoverflow.com/a/17227764/19020 to load controllers in 
        //  another assembly.  Another way to do this is to create a custom assembly resolver
        private Type valuesControllerType = typeof(ValuesController);

        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();

            //  Enable attribute based routing
            //  http://www.asp.net/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            appBuilder.UseWebApi(config);
        }
    }

    public class ConnectRest
    {
        private string _baseAddress = "http://localhost:8050/";
        private IDisposable _server = null;

        public void Start()
        {
            var options = new Microsoft.Owin.Hosting.StartOptions();
            options.Urls.Add(_baseAddress);
            options.AppStartup = this.GetType().AssemblyQualifiedName;
            options.ServerFactory = "Microsoft.Owin.Host.HttpListener";
            _server = WebApp.Start<Startup>(options);
        }

        public void Stop()
        {
            if (_server != null)
            {
                _server.Dispose();
            }
        }
    }
}
