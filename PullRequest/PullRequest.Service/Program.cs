using System;
using Microsoft.Owin.Hosting;
using PullRequest.Service.Config;
using Topshelf;

namespace PullRequest.Service
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<PullRequestService>(s =>
                {
                    s.ConstructUsing(name => new PullRequestService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("PullRequest - Domain Service");
                x.SetDisplayName("PullRequest - Domain Service");
                x.SetServiceName("PullRequest.Service");
            });
        }
    }

    public class PullRequestService
    {
        private IDisposable webApp;

        public void Start()
        {
            var baseUri = "http://localhost:8183";

            Console.WriteLine("Starting PullRequest Domain Service...");
            webApp = WebApp.Start<Startup>(baseUri);
            Console.WriteLine("Server running at {0} - press Enter to quit. ", baseUri);
        }

        public void Stop()
        {
            webApp.Dispose();
        }
    }
}