using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HANEL.APP.CONSOLE
{
    public static class MyConsole
    {
        public static void Header(params ConsoleInputModel[] consoleInputModels)
        {
            var text = MyConsoleText(consoleInputModels);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(text);
        }
        public static void Normal(params ConsoleInputModel[] consoleInputModels)
        {
            var text = MyConsoleText(consoleInputModels);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(text);
        }
        public static void Error(params ConsoleInputModel[] consoleInputModels)
        {
            var text = MyConsoleText(consoleInputModels);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
        }

        public static void Warning(params ConsoleInputModel[] consoleInputModels)
        {
            var text = MyConsoleText(consoleInputModels);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
        }

        public static void Success(params ConsoleInputModel[] consoleInputModels)
        {
            var text = MyConsoleText(consoleInputModels);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
        }

        public static void Danger(params ConsoleInputModel[] consoleInputModels)
        {
            var text = MyConsoleText(consoleInputModels);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(text);
        }

        static string MyConsoleText(params ConsoleInputModel[] consoleInputModels)
        {
            string spacing(int length)
            {
                var res = "";
                for (int i = 0; i < length; i++)
                {
                    res += ' ';
                }

                return res;
            }

            string consoleString = "";
            foreach (var item in consoleInputModels)
            {
                if (consoleString.Length != 0) consoleString += " - ";
                consoleString += item.Text.Length < item.Length ? item.Text + spacing(item.Length - item.Text.Length) : item.Text.Substring(0, item.Length);
            }

            return consoleString;


        }

    }

    public class ConsoleInputModel
    {
        public string Text { get; set; }
        public int Length { get; set; }
    }
}
