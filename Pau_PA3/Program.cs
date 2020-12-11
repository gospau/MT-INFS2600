using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pau_PA3
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            Random rng = new Random();
            Console.WriteLine("\tStep right up and take a guess!");

            int counter = 0;
            string letter;
            int tokens = 100;
            bool parseO;
               
            while (tokens > 0)
            {
                Console.WriteLine("\nYou currenly have {0} tokens", tokens);
                Console.WriteLine("(A) 10\t(B) 50\t(C) All");
                Console.Write(">>");
                int number = rng.Next(1, 4);
                letter = Console.ReadLine();
                while (letter != "A" && letter != "B" && letter != "C")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Invalid option. Try again:");
                    letter = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                }
                while (letter == "B" && tokens < 50)
                {
                    Console.WriteLine("Sorry you do not have enoght tokens.");
                    letter = Console.ReadLine();
                }

                int guestnumber;
                Console.Write("Pick a number betwwen 1 and 3: ");
                parseO = int.TryParse(Console.ReadLine(), out guestnumber);

                while (parseO != true || (guestnumber > 3 || guestnumber < 1))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Invalid number. Try again:");
                    parseO = int.TryParse(Console.ReadLine(), out guestnumber);
                    Console.ForegroundColor = ConsoleColor.White;
                }


                if (number == guestnumber && letter == "A")
                {
                    tokens = 20 + tokens;
                    counter++;
                }
                if (number == guestnumber && letter == "B")
                {
                    tokens = 150 + tokens;
                    counter++;
                }
                if (number == guestnumber && letter == "C")
                {
                    tokens = tokens * 5;
                    counter++;
                }

                if (letter == "A")
                {
                    tokens = tokens - 10;
                }
                if (letter == "B")
                {
                    tokens = tokens - 50;
                }
                if (letter == "C" && guestnumber != number)
                {
                    tokens = tokens - tokens;
                }


                if (guestnumber != number)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorrect. The answer was {0}", number);
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
            Console.WriteLine("\nYou are out of tokens. You won {0} games!", counter);

            Console.WriteLine("\nPress any key to exit");
            Console.ReadKey();
        }
    }
}
