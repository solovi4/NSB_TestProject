using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultipleEndPointNSB
{
    class Program
    {
        static async Task Main(string[] args)
        {
            EndPointReAuth endPointReAuth = new EndPointReAuth();
            EndPointPfsServices endPointPfsServices = new EndPointPfsServices();

            await endPointPfsServices.Start();
            //await endPointReAuth.Start();

            Console.ReadLine();

            await endPointPfsServices.Stop();

        }
    }
}
