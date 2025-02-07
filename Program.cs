namespace Meteorology_Sim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WeatherSystem weatherSystem = new WeatherSystem();
            Console.WriteLine(weatherSystem.Time);
        }
    }
}
