using Microsoft.Extensions.Hosting;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace HostServiceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new HostBuilder().ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<MyTimerHostedService>();
                services.AddHostedService<MyBackGroundService>();
            }).Build();

            host.Run();

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
