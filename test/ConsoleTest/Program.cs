using JsonStringFormatter;

namespace ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var txt = File.ReadAllText("Sample.json");

            JsonFormater.PrintJsonToConsole(txt);
        }
    }
}