using System;
using System.Collections.Generic;

namespace NICE_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Dictionary<string, double>[] units = { length, mass };
                string[] unitChoices = { "meters", "kilograms" };
                Console.Write("\n Select units:\n\t1. Length\n\t2. Mass\n\n Selection: ");
                int selection = Convert.ToInt32(Console.ReadLine()) - 1;
                Dictionary<string, double> usingDict = units[selection];
                Console.Write($"\n Enter your value in {unitChoices[selection]}: ");
                double input = Convert.ToDouble(Console.ReadLine());

                double closest = 1e10;
                int closestDigits = 99;
                string unitName = "";

                foreach (KeyValuePair<string, double> pair in usingDict)
                {
                    double closeness = 0;
                    int digits = 0;
                    int inDigits = GetDigits(input) - 3;
                    double newInput = input / (Math.Pow(10, inDigits));
                    double newPair;

                    if (pair.Value >= 1)
                    {
                        digits = GetDigits(pair.Value) - 1;
                        newPair = pair.Value / (Math.Pow(10, digits));
                    }
                    else
                    {
                        digits = GetDigits(pair.Value) + 2;
                        int x = -digits;
                        newPair = pair.Value * 10;
                        while (x-- > 0)
                        {
                            newPair = newPair * 10;
                        }
                    }

                    closeness = 420 - ((newInput / (1 / newPair)));

                    if (digits < 0) digits *= -1;

                    if (Math.Abs(closeness) < Math.Abs(closest))
                    {
                        closest = closeness;
                        closestDigits = digits;
                        unitName = pair.Key;
                    }
                }
                double value = usingDict.GetValueOrDefault(unitName);
                double answer = (input / (1 / value));

                Console.Write($"\n The closest value is {answer.ToString("000.00000xE0")} {unitName}\n");
                if (Math.Abs(420 - answer) < 2) Console.WriteLine(" That's pretty NICE!");
                else if (Math.Abs(420 - answer) < 5) Console.WriteLine(" We were on the verge of greatness...");
                Console.ReadLine();
                Console.Clear();
            }
        }
        static int GetDigits(double dec)
        {
            int count = 0;
            if (dec >= 1)
            {
                while (dec >= 1)
                {
                    count++;
                    dec = dec / 10;
                }
                return count;
            }
            else
            {
                while (dec <=1)
                {
                    count--;
                    dec = dec * 10;
                }
                return count;
            }
            return count;
        }
        static Dictionary<string, double> length = new Dictionary<string, double>()
          { 
            { "centimeters", 1e2},
            { "millimeters", 1e3},
            { "microns", 1e6},
            { "nanometers", 1e9},
            { "kilometers", 1e3},
            { "inches", 3.937008e1},
            { "feet", 3.28084e0},
            { "yards", 1.093613e0},
            { "miles", 6.21371e-4},
            { "nautical miles", 5.39957e-4},
            { "sun radii", 1.4374e-9},
            { "light years", 1.057e-16 },
            { "astronomical units", 6.68459e-12},
            { "parsecs", 3.24078e-17},
          };
        static Dictionary<string, double> mass = new Dictionary<string, double>()
        {
            
            { "grams(g)" , 1e3 },
            { "milligrams(mg)", 1e6 },
            { "micrograms(ug)", 1e9 },
            { "decagrams(dag)", 1e2 },
            { "metric tons(t)", 1e-3 },
            { "ounces(oz)", 3.527396e1 },
            { "pounds(lb)", 2.204623e0 },
            { "stones(stone)", 1.57473e-1 },
            { "US short tons(US ton)", 1.102311e-3 },
            { "US long tons(long ton)", 9842e-4 },
            { "drachms(dr)", 5.64383e2 },
            { "Earths(earths)", 1.673360107e-25},
            { "Suns(suns)", 5.02785e-31},
            { "electron rest mass(me)", 1.098776912280988e+30 },
            { "proton rest mass(mp)", 1.6726231e+27},
            { "neutron rest mass(mn)", 1.674929e+27},
            { "atomic mass unit(u)", 6.022136651e+26},
            { "troy ounce(oz t)", 3.215075e1 }
        };
    }
}
