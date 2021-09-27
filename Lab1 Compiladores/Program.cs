using System;

namespace Lab1_Compiladores
{
    class Program
    {
        static void Main(string[] args)
        {
            //Scanner scanner = new Scanner("123-45+-*/");
            //Token nexttoken;
            //do
            //{
            //    nexttoken = scanner.GetToken();
            //    Console.WriteLine("token: {0}, valor: {1}", nexttoken.Tag, nexttoken.Value);
            //} while (nexttoken.Tag != TokenType.EOF);

            //-2+8*4/-(5-3)
            //string regexp = Console.ReadLine();
            Parser prser = new Parser();
            Console.WriteLine(prser.Parse("-2+8*4/(5-3)"));
            Console.WriteLine("EXITO");
            Console.ReadKey();
        }
    }
}
