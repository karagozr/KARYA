
using HANEL.COM.INVOICE_SERVICE;
using System;
using System.Timers;
using System.Configuration;

namespace HANEL.COM.INVOICE_SERVICE
{
    class Program
    {
        static Timer timer;
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("TIMER :: {0:HH:mm:ss.fff}", e.SignalTime);

            ProgramService startService = new ProgramService();
            startService.RunService();

            
        }
        static void Main(string[] args)
        {
            //timer = new Timer(500000);
            //timer.Elapsed += OnTimedEvent;
            //timer.AutoReset = true;
            //timer.Enabled = true;
            //15298	3160	65079871-7439-40c6-8b2e-5586f641fe1c	FATURA	FT12021000001586	2021-03-27 00:00:00.0000000	2021-03-27 07:02:36	2021-03-29 09:30:37.4732244	NULL	NULL	7990391423	urn:mail:defaultgb@bidolubaski.com	İstanbul	Ümraniye	Dudullu OSB Mah. 2. Cadde	NULL	216 7060232	NULL	ŞANS BASIM SAN. VE TİC. A.Ş	NULL	
            //3850620268	NULL	7.56	Fethiye Enerji San. ve Tic. A.S	NULL	49.56	0	42.00	49.56
            ProgramService startService = new ProgramService();
            startService.RunService();
            //var res = startService.InvoiceDocument("3850620268", "65079871-7439-40c6-8b2e-5586f641fe1c","PDF");
            //var data = res.Result;
            Console.ReadLine();

            //startService.Dispose();
            Console.ReadLine();

        }
    }
}
