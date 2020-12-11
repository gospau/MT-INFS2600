using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pau_PA5
{
    class Program
    {
        static void Main(string[] args)
        {
            InitializeApp();

            List<double> costs = new List<double>();
            int mealCount = 1;

            string choice = MenuPrompt();

            while( choice.ToUpper() != "Q")
            {
                double cost = DoublePrompt(String.Format("Enter cost of meal {0}: ", mealCount));
                costs.Add(cost);
                mealCount++;

                choice = MenuPrompt();
            }

            if( costs.Count == 0 )
            {
                Console.Write("\nNo meals entered. Goodbye.");
            }
            else
            {
                double tip = DoublePrompt("\nWhat percentage would you like to tip:  ");
                double totalCost = CalculateTotalCost(costs, 9.95, tip);

                PrintReceipt(totalCost);
            }

            Console.Write("\nPress any key to exit...");
            Console.ReadKey();
        }
        static void InitializeApp ()
        {
            Console.WriteLine("\tPau PA5");
        }
        static string MenuPrompt()
        {
            Console.Write("\nEnter 'Q' to quit, or enter to continue:");
            string result = Console.ReadLine();

            return result;
        }
        static double DoublePrompt( string prompttext)
        {
            double value;
            Console.Write(prompttext);
            bool parseOK = double.TryParse(Console.ReadLine(), out value);

            while (parseOK != true)
            {
                Console.Write("Try again: ");
                parseOK = double.TryParse(Console.ReadLine(), out value);
            }

            return value;
        }
        static double CalculateTotalCost( List<double> cost, double tax, double tip )
        {
            double final;
            double totalCost = cost.Sum();
            tip = totalCost * tip / 100;
            tax = totalCost * tax / 100;
            final = totalCost + tax + tip;

            return final;
        }
        static void PrintReceipt( double CalculateTotalCost)
        {
            Console.WriteLine("\nToatal: {0:C}", CalculateTotalCost);
        }
    }
}
