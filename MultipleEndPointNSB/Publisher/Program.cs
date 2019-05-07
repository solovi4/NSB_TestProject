using Messages;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publisher
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ReloadServicePublisher reloadServicePublisher = new ReloadServicePublisher();
            ReAuthPublisher reAuthPublisher = new ReAuthPublisher();
            await reloadServicePublisher.Start();
            await reAuthPublisher.Start();
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                await reloadServicePublisher.Send();
                await reAuthPublisher.Send();
                Console.WriteLine("Sended");                
            }
            await reAuthPublisher.Stop();
            await reloadServicePublisher.Stop();
        }
    }
}
