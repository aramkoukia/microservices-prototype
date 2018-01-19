using System;
using Microsoft.Owin.Hosting;
using PullRequest.ReadModels.Service.Config;
using Topshelf;

namespace PullRequest.ReadModels.Service
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<PullRequestReadModelsService>(s =>
                {
                    s.ConstructUsing(name => new PullRequestReadModelsService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("PullRequest - Read Models Service");
                x.SetDisplayName("PullRequest - Read Models Service");
                x.SetServiceName("PullRequest.ReadModels.Service");
            });
        }
    }

    public class PullRequestReadModelsService
    {
        private IDisposable webApp;

        public void Start()
        {
            var baseUri = "http://localhost:8182";

            Console.WriteLine("Starting PullRequest Read Model Service...");
            webApp = WebApp.Start<Startup>(baseUri);
            Console.WriteLine("Server running at {0} - press Enter to quit. ", baseUri);
        }

        public void Stop()
        {
            webApp.Dispose();
        }
    }
}