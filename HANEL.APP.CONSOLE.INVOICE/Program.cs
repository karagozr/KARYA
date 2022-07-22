using System;

namespace HANEL.APP.CONSOLE.INVOICE
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Test test = new Test();

            test.TTTT();

        }
    }

    public class Test : Logger<Test>
    {
        public void TTTT()
        {
            ErrorLog("asdasdasd {0}", 32);
        }
    }
}
