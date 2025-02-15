namespace Meteorology_Sim
{
    internal class Program
    {
        static Random rnd = new Random();
        static string[] mainMenu = { "Cast weather effects", "Continue simulation", "Exit" };
        static string[] simulationMenu = { "Back to Main Menu", "Cast rain", "Cast snow", "Cast sunny weather", "Cast thunderstorm", "Cast wind" };
        static int highlightPos;
        static string[] activeMenu = mainMenu;
        static Simulation simulation = new Simulation(20);
        static Weather nextWeather = simulation.Weathers[rnd.Next(simulation.Weathers.Count)];

        static void Main(string[] args)
        {
            simulation.RandomizeTiles();
            DrawMenu();
        }


        static ConsoleKey Menu(string[] options)
        {
            Console.Clear();
            Console.WriteLine("MetSim - Meteorology Simulation\n");
            Console.WriteLine($"Weather forecast: {nextWeather.Name} | Intensity (1-10): {nextWeather.Intensity:f2} | Duration: approx. {nextWeather.Minutes} minutes\n");


            if (highlightPos > options.Length - 1) highlightPos = 0;
            else if (highlightPos < 0) highlightPos = options.Length - 1;

            for (int i = 0; i < options.Length; i++)
            {
                if (i == highlightPos) Highlight();
                Console.WriteLine($"- {options[i]} -");
                Highlight(false);
            }


            return Console.ReadKey(true).Key;
        }

        static void Highlight(bool b = true)
        {
            if (b)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        static void Simulation()
        {
            Console.Clear();
            Console.WriteLine("MetSim - Meteorology Simulation\n");
            Console.WriteLine($"Weather forecast: {nextWeather.Name} | Intensity (1-10): {nextWeather.Intensity:f2} | Duration: approx. {nextWeather.Minutes} minutes\n");

            DisplayExplanation();
            DisplayGarden();
            activeMenu = simulationMenu;

            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("\n\nPress ENTER to cast weather");
            Console.ReadKey(true);


            Console.Clear();
            Console.WriteLine("MetSim - Meteorology Simulation\n");
            Console.WriteLine($"Simulating weather: {nextWeather.Name}");

            Cast(nextWeather);

            DisplayExplanation();
            DisplayGarden();

            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("\n\nPress ENTER to return to main menu");
            Console.ReadKey(true);
        }

        static void Cast(Weather weather)
        {
            simulation.RandomizeTiles();
        }

        static void DisplayExplanation()
        {
            Console.WriteLine("\nSign explanation:");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Wet ground");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Dry ground");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Not seeded");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Ruined land\n");
            Console.ForegroundColor = ConsoleColor.White;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("C - Corn");
            Console.WriteLine("P - Potato");
            Console.WriteLine("T - Tomato");
        }

        static void DisplayGarden()
        {
            for (int i = 0; i < simulation.Tiles.Count; i++)
            {
                if (i % simulation.Size == 0) Console.WriteLine();
                Console.Write(simulation.Tiles[i]);
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        static void SetNextWeather(string name)
        {
            Console.Clear();
            Console.WriteLine($"Set parameters for simulated weather: {name}");
            Console.WriteLine("---------------------------------------------");
            try
            {
                Console.Write("| Intensity (1-10): ");
                double a = Convert.ToDouble(Console.ReadLine());

                Console.Write("| Duration (10< minutes): ");
                int b = Convert.ToInt32(Console.ReadLine());

                nextWeather = new Weather(name, a, b);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey(true);
            }
        }

        static void DrawMenu()
        {
            ConsoleKey menu;
            do
            {
                Console.BackgroundColor = ConsoleColor.Black;
                menu = Menu(activeMenu);
                switch (menu)
                {
                    case ConsoleKey.DownArrow: highlightPos++; break;
                    case ConsoleKey.UpArrow: highlightPos--; break;
                    case ConsoleKey.Enter:
                        {
                            if (activeMenu == mainMenu)
                            {
                                switch (highlightPos)
                                {
                                    case 0: activeMenu = simulationMenu; break;
                                    case 1: Simulation(); break;
                                    case 2: return;
                                }
                            }
                            else if (activeMenu == simulationMenu)
                            {
                                switch (highlightPos)
                                {
                                    case 0: activeMenu = mainMenu; break;
                                    case 1: SetNextWeather("Rain"); break;
                                    case 2: SetNextWeather("Snow"); break;
                                    case 3: SetNextWeather("Sunny weather"); break;
                                    case 4: SetNextWeather("Thunderstorm"); break;
                                    case 5: SetNextWeather("Wind"); break;
                                }
                            }
                        }; highlightPos = 0; break;
                }
            } while (menu != ConsoleKey.Escape);
        }
    }
}
