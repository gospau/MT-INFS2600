using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pau_PA4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "PA4";

            Console.WriteLine("\tMovie Rating Aggregator");

            List<double> rating = new List<double>();
            List<string> movieList = new List<string>();

            double star;
            bool parseOk;
            string movie = "";

            while (movie != "Q")
            {
                Console.Write("Enter a movie title ( or 'Q' to Quit ): ");
                movie = Console.ReadLine();

                if (movie != "Q")
                {
                    Console.Write("Rate '{0}' 0.5 to 5 stars: ", movie);
                    parseOk = double.TryParse(Console.ReadLine(), out star);

                    while (parseOk != true || star < .5 || star > 5)
                    {
                        Console.Write("Try again. 0.5 to 5 stars: ");
                        parseOk = double.TryParse(Console.ReadLine(), out star);
                    }

                    rating.Add(star);

                    if (star >= 3)
                    {
                        movieList.Add(movie);
                    }
                }
                
            }

            if (rating.Count > 0)
            {
                Console.WriteLine("\nAverage rating of entered movies is {0:F}.", rating.Average());
            }

            if (rating.Count == 0)
            {
                Console.WriteLine("\nNo movies were entered.");
            }

            else
            {
                
                Console.WriteLine("\nCertified Star titles:");
                for (int i = 0; i < movieList.Count; i++)
                {
                    Console.WriteLine("> {0}", movieList[i]);
                }

            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
