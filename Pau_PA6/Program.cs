using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pau_PA6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tThe Robot Factor");

            List<Robot> robots = new List<Robot>();

            int howmany;
            bool parseOK;
            Console.Write("\nHow many robots shall we build: ");
            parseOK = int.TryParse(Console.ReadLine(),out howmany);

            while( parseOK != true)
            {
                Console.Write("Invalid value please enter again: ");
                parseOK = int.TryParse(Console.ReadLine(), out howmany);
            }
            
            for (int i= 1; i <= howmany; i++)
            {
                string roname;
                int numberofbat;
                double resis;
                

                Console.Write("\nEnter Robot {0} ID: ", i);
                roname = Console.ReadLine();

                Console.Write("Enter Robot {0} batteries: ", i);
                parseOK = int.TryParse(Console.ReadLine(), out numberofbat);
                while (parseOK != true)
                {
                    Console.Write("Invalid number. Please try again: ");
                    parseOK = int.TryParse(Console.ReadLine(), out numberofbat);
                }

                Console.Write("Enter Robot {0} resistance: ", i);
                parseOK = double.TryParse(Console.ReadLine(), out resis);
                while (parseOK != true)
                {
                    Console.Write("Invalid number. Please try again: ");
                    parseOK = double.TryParse(Console.ReadLine(), out resis);
                }

                Robot x = new Robot(roname, numberofbat, resis);

                robots.Add(x);

            }
            
            double maxtime = 0;
            string newID = "";
            

            int batteriescount = 0;
            double power = 0;
            int counter=0;

            for (int i = 0; i < robots.Count; i++)
            {

                batteriescount += robots[i].Batteries;

                power += robots[i].GetPower();
                counter++;
                
                
                if(robots[i].GetRunTime() > maxtime )
                {
                    maxtime = robots[i].GetRunTime();
                    newID = robots[i].ID;
                }
            }

            power = power / counter;

            Console.WriteLine("\nTotal Batteries required: {0} ", batteriescount);
            
            Console.WriteLine("Average power of all robots: {0:F}",power);

            Console.WriteLine("Robot {0} has longest runtime at {1:F} hours.", newID, maxtime);

            Console.WriteLine("\nRobot Summary: ");
            for (int i =0; i < robots.Count; i++)
            {
                robots[i].Summary();
            }
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
