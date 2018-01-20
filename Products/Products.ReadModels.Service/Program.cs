using System;
using Microsoft.Owin.Hosting;
using Topshelf;

namespace Products.ReadModels.Service
{
    class Program
    {
        public static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<ProductsReadModelService>(s =>
                {
                    s.ConstructUsing(name => new ProductsReadModelService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("Products - Read Models Service");
                x.SetDisplayName("Products - Read Models Service");
                x.SetServiceName("Products.ReadModels.Service");
            });
        }
    }
    public class ProductsReadModelService
    {
        private IDisposable webApp;
        public void Start()
        {
            const string baseUri = "http://localhost:8181";
            Console.WriteLine("Starting Products Read Model Service...");
            webApp = WebApp.Start<Startup>(baseUri);
            Console.WriteLine("Server running at {0} - press Enter to quit. ", baseUri);
        }

        public void Stop()
        {
            webApp.Dispose();
        }
    }
}
