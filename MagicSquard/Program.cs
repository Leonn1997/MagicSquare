using System;

namespace MagicSquard
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var envo = new SquardProblem();
            var besti = envo.BestDude();
            Console.WriteLine("And The Winner is!");
            envo.Envo.PrintCasanova();
            Console.ReadLine();
           }
    }
}
