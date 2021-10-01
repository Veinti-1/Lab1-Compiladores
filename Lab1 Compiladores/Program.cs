using System;

namespace Lab1_Compiladores
{
    class Program
    {
        static void Main(string[] args)
        {
            //-2+8*4/(5-3)
            string entrada = Console.ReadLine(); 
            Parser prser = new Parser();
            Console.WriteLine(prser.Parse(entrada)); 
            Console.WriteLine("EXITO");
            Console.ReadKey();
        }
    }
}
