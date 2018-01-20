using System;
using Microsoft.Owin.Hosting;
using Sales.ReadModels.Service.Config;
using Topshelf;

namespace Sales.ReadModels.Service
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<SalesReadModelsService>(s =>
                {
                    s.ConstructUsing(name => new SalesReadModelsService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("Sales - Read Models Service");
                x.SetDisplayName("Sales - Read Models Service");
                x.SetServiceName("Sales.ReadModels.Service");
            });
        }
    }

    public class SalesReadModelsService
    {
        private IDisposable webApp;

        public void Start()
        {
            var baseUri = "http://localhost:8182";

            Console.WriteLine("Starting Sales Read Model Service...");
            webApp = WebApp.Start<Startup>(baseUri);
            Console.WriteLine("Server running at {0} - press Enter to quit. ", baseUri);
        }

        public void Stop()
        {
            webApp.Dispose();
        }
    }
}