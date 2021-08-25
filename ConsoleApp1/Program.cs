using NETSIS.NETOPENX.REST.Services;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            NetsisMuhasebeService netsisCariService = new NetsisMuhasebeService(new KARYA.MODEL.Entities.Netsis.Login { });

            var res = netsisCariService.ListMuhReferans().Result;
        }
    }
}
