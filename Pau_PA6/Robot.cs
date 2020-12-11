using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pau_PA6
{
    class Robot
    {
        private string id;
        private int batteries;
        private double resistance;

        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                if ( value.Length == 4 || value.Length == 5)
                {
                    id = value;
                }
                else
                {
                    id = "XX-XX";
                }
            }
        }

        public int Batteries
        {
            get
            {
                return batteries;
            }
            set
            {
                if ( value >= 2 && value <= 6 )
                {
                    batteries = value;
                
                }
                else
                {
                    batteries = 2;
                }
            }
        }

        public double Resistance
        {
            get
            {
                return resistance;
            }
            set
            {
                if ( value > 0)
                {
                    resistance = value;
                }
                else
                {
                    resistance = 100;
                }
            }
        }

        public Robot()
        {
            id = "XX-XX";
            batteries = 2;
            resistance = 100;
        }

        public Robot(string id2, int b, double r)
        {
            ID = id2;
            Batteries = b;
            Resistance = r;
        }

        public double GetPower()
        {
            double voltage = 1.5 * batteries;
            double current;

            current = voltage / resistance;

            double power = voltage * current;
            return power;
        }

        public double GetRunTime()
        {
            double time = (3.75*batteries) / GetPower();
            return time;

        }

        public void Summary()
        {
            double power = GetPower();
            double runtime = GetRunTime();
            Console.WriteLine("{0} : {1} Batteries - {2:F} Watts ({3:F} hours runtime)", id, batteries, power, runtime);
        }

        
    }
}
