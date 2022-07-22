using KARYA.CORE.Helpers;
using System;
using System.Net;

namespace HANEL.APP.CONSOLE
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls12;

            MyConsole.Header(
                new ConsoleInputModel
                {
                    Text = DateTime.Now.ToString(),
                    Length = 20
                }, new ConsoleInputModel
                {
                    Text = "SERVICE START",
                    Length = 20
                }, new ConsoleInputModel
                {
                    Text = "( HANEL APP CONSOLE) ",
                    Length = 35
                }
            );




            InvoiceServiceWorker worker = new InvoiceServiceWorker();

            worker.FaturaUpdate();

            Console.WriteLine("Press for close ...");
            Console.ReadLine();

            
        }


        
        

    }


    
}
