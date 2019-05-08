using System;
using System.Threading.Tasks;

namespace Publisher
{
    class Program
    {
        static async Task Main()
        {
            Console.Title = "Publisher";
            ReloadServicePublisher reloadServicePublisher = new ReloadServicePublisher();
            ReAuthPublisher reAuthPublisher = new ReAuthPublisher();
            await reloadServicePublisher.Start().ConfigureAwait(false);
            await reAuthPublisher.Start().ConfigureAwait(false);
            Console.WriteLine("Press any key to send messages, exept esc, esc is exit");
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                await reloadServicePublisher.Send().ConfigureAwait(false);
                await reAuthPublisher.Send().ConfigureAwait(false);
                Console.WriteLine("Sended");
            }
            await reAuthPublisher.Stop().ConfigureAwait(false);
            await reloadServicePublisher.Stop().ConfigureAwait(false);
        }
    }
}
