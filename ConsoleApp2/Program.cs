using HANEL.BUSINESS.Concrete.Hotel;
using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var hotelReportManager = new Test();

            var res = hotelReportManager.RoomSaleAgentCountryMarketData();

        }
    }
}
