using System;
using System.Linq;

namespace ParalellApp
{
    class Program
    {
        class Driver
        {
            public string Name { get; set; }
            public string TeamName { get; set; }
        }


        static void Main(string[] args)
        {

            Driver[] drivers = new Driver[]
{
                new Driver {Name="Lewis Hamilton", TeamName="Mercedes"},
                new Driver {Name="Valtteri Bottas", TeamName="Mercedes"},
                new Driver {Name="Sebastian Vettel", TeamName="Ferrari"},
                new Driver {Name="Charles Leclerc", TeamName="Ferrari"},
                new Driver {Name="Max Verstappen", TeamName="Red Bull Racing-Honda"},
                new Driver {Name="Pierre Gasly", TeamName="Red Bull Racing-Honda"},
                new Driver {Name="Daniel Ricciardo", TeamName="Renault"},
                new Driver {Name="Nico Hülkenberg", TeamName="Renault"},
                new Driver {Name="Romain Grosjean", TeamName="Haas-Ferrari"},
                new Driver {Name="Kevin Magnussen", TeamName="Haas-Ferrari"},
                new Driver {Name="Lando Norris", TeamName="McLaren-Renault"},
                new Driver {Name="Carlos Sainz Jr.", TeamName="McLaren-Renault"},
                new Driver {Name="Kimi Räikkönen", TeamName="Alfa Romeo Racing-Ferrari"},
                new Driver {Name="Antonio Giovinazzi", TeamName="Alfa Romeo Racing-Ferrari"},
                new Driver {Name="Alexander Albon", TeamName="Scuderia Toro Rosso-Honda"},
                new Driver {Name="Daniil Kvyat", TeamName="Scuderia Toro Rosso-Honda"},
                new Driver {Name="George Russell", TeamName="Williams-Mercedes"},
                new Driver {Name="Robert Kubica", TeamName="Williams-Mercedes"},
         };

            string input;
            Console.Write("Would you like to see and ordered race?:Y/N");
            input = Console.ReadLine();

            System.Linq.ParallelQuery<Driver> result;

            if (input.ToUpper() == "N")
            {
                result = from driver in drivers.AsParallel() select driver;

            }
            else
            {
                result = from driver in drivers.AsParallel().AsOrdered() select driver;
            }

            int position = 1;
            foreach (var driver in result)
            {
                Console.WriteLine("In fininshing position " + position + " the driver is " + driver.Name + " from team " + driver.TeamName);
                position++;
            }


            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
