using System;
using Microsoft.Owin.Hosting;
using Topshelf;

namespace Products.Service
{
    public class Program
    {
        public static void Main(string[] args)
        { 
            HostFactory.Run(x => 
            {
                x.Service<ProductsService>(s => 
                {
                    s.ConstructUsing(name => new ProductsService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("Products - Domain Service");
                x.SetDisplayName("Products - Domain Service");
                x.SetServiceName("Products.Service");
            });
        }
    }

    public class ProductsService
    {
        private IDisposable webApp;
        public void Start()
        {
            const string baseUri = "http://localhost:8180";
            Console.WriteLine("Starting web Server...");
            webApp = WebApp.Start<Startup>(baseUri);
            Console.WriteLine("Server running at {0} - press Enter to quit. ", baseUri);
        }

        public void Stop()
        {
            webApp.Dispose();
        }
    }

}
