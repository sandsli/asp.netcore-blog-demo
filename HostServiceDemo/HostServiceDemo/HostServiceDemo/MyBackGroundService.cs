using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HostServiceDemo
{
    public class MyBackGroundService : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("MyBackGroundService doing");

                //延迟500毫秒执行 相当于使用了定时器
                await Task.Delay(500, stoppingToken);
            }
        }
    }
}
