namespace Meteorology_Sim
{
    internal class Program
    {
        static string[] mainMenu = { "Normal simulation", "Game simulation" };
        static string[] simulationMenu = { "Cast rain", "Cast thunder" };
        static int highlightPos;
        static void Main(string[] args)
        {
            ConsoleKey menu;

            WeatherSystem weatherSystem = new WeatherSystem();
            Console.WriteLine(weatherSystem.Time);

            string[] activeMenu = mainMenu;
            do
            {
                menu = Menu(activeMenu);
                switch (menu)
                {
                    case ConsoleKey.DownArrow: highlightPos++; break;
                    case ConsoleKey.UpArrow: highlightPos--; break;
                    case ConsoleKey.Enter:
                        {
                            switch (highlightPos)
                            {
                                case 0: activeMenu = simulationMenu; break;
                                case 1: Console.WriteLine("b"); Console.ReadKey(); break;
                            }
                        }; break;
                }
            } while (menu != ConsoleKey.Escape);

        }


        static ConsoleKey Menu(string[] options)
        {
            Console.Clear();

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
    }
}
