using System;
using Microsoft.Owin.Hosting;
using Sales.Service.Config;
using Topshelf;

namespace Sales.Service
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<SalesService>(s =>
                {
                    s.ConstructUsing(name => new SalesService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("Sales - Domain Service");
                x.SetDisplayName("Sales - Domain Service");
                x.SetServiceName("Sales.Service");
            });
        }
    }

    public class SalesService
    {
        private IDisposable webApp;

        public void Start()
        {
            var baseUri = "http://localhost:8183";

            Console.WriteLine("Starting Sales Domain Service...");
            webApp = WebApp.Start<Startup>(baseUri);
            Console.WriteLine("Server running at {0} - press Enter to quit. ", baseUri);
        }

        public void Stop()
        {
            webApp.Dispose();
        }
    }
}