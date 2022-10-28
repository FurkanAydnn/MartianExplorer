using System;
using System.Threading;

namespace MartianExplorer.Helpers
{
    public class ConsoleHelper
    {
        public static void WriteLetterByLetter(string text, int miliSeconds = 1)
        {
            foreach (var letter in text)
            {
                Console.Write(letter);
                Thread.Sleep(miliSeconds);
            }

            Console.WriteLine();
        }
    }
}
