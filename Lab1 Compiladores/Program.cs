using System;

namespace Lab1_Compiladores
{
    class Program
    {
        static void Main(string[] args)
        {
            //string regexp = Console.ReadLine();
            Parser prser = new Parser();
            Console.WriteLine(prser.Parse("-2+8*4/(5-3)"));
            Console.WriteLine("EXITO");
            Console.ReadKey();
        }
    }
}
