using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Scheduler
{
    public class Service : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await MyMethodAsync();
                //await Task.Delay(TimeSpan.FromMinutes(15), stoppingToken); // Runs every 5 minutes
                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken); // Runs every 5 minutes
            }
        }

        private async Task MyMethodAsync()
        {
            // Your logic here
            Console.WriteLine($"Method executed at {DateTime.Now}");
            await Task.CompletedTask;
        }
    }
}