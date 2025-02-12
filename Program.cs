namespace Meteorology_Sim
{
    internal class Program
    {
        static string[] mainMenu = { "Cast weather effects", "View simulation" };
        static string[] simulationMenu = { "Back to Main Menu", "Cast rain", "Cast snow", "Cast sunny weather", "Cast thunderstorm", "Cast wind" };
        static int highlightPos;
        static string[] activeMenu = mainMenu;
        static Simulation simulation = new Simulation(20);

        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 50);
            simulation.RandomizeTiles();
            DrawMenu();
        }


        static ConsoleKey Menu(string[] options)
        {
            Console.Clear();
            Console.WriteLine("MetSim - Meteorology Simulation\n");


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
            Console.WriteLine("Simulation for a garden");
            DisplayExplanation();
            DisplayGarden();
            activeMenu = simulationMenu;
            Console.ReadKey(true);
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
                                }
                            }
                            else if (activeMenu == simulationMenu)
                            {
                                switch (highlightPos)
                                {
                                    case 0: activeMenu = mainMenu; break;
                                    case 1: break;
                                }
                            }
                        }; highlightPos = 0; break;
                }
            } while (menu != ConsoleKey.Escape);
        }
    }
}
