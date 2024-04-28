
using System;

namespace AbstractFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();

            Console.WriteLine("Press enter key to exit ...");
            Console.ReadKey();
        }
    }
}
