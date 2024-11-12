
// See https://aka.ms/new-console-template for more information

using SecretNumber.GameHost;

internal class Program
{
    private static void Main(string[] args)
    {
        IGameHostLauncher gameHostLauncher = new ConsoleGameHostLauncher();

        Console.WriteLine(gameHostLauncher.GameLaunched());

        while (true)
        {
            Console.Write("Введите число или команду: ");

            var input = Console.ReadLine();

            if (input == "new")
            {
                Console.Clear();
            }

            Console.WriteLine(gameHostLauncher.ProcessInput(input));

            if (input == "quit" || input == "q")
            {
                break;
            }
        }
    }
}