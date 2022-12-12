namespace HeroesCreator;

public static class UserInterface
{
    public static MainMenuResult ShowMainMenu()
    {
        Console.WriteLine("Welcome to Hero Creator. What would you like to do?");
        Console.WriteLine();
        Console.WriteLine("1. Add a hero");
        Console.WriteLine("2. Remove a hero");
        Console.WriteLine("3. List out heroes");
        Console.WriteLine("4. Quit");
        Console.WriteLine();

        var userInput = Console.ReadLine();

        var result = userInput?.ToLower() switch
        {
            "1" => MainMenuResult.AddHero,
            "2" => MainMenuResult.RemoveHero,
            "3" => MainMenuResult.ListOutHeroes,
            "4" => MainMenuResult.Quit,
            _ => MainMenuResult.Invalid
        };

        if (result == MainMenuResult.Invalid)
        {
            ShowInvalidInputMessage(userInput!);
        }

        return result;
    }

    public static Hero ShowAddHeroMenu()
    {
        Console.WriteLine("Enter the name of the hero");
        var heroName = Console.ReadLine();

        Console.WriteLine("Enter the power level of the hero.");
        var powerLevel = Console.ReadLine();
        var powerLevelInt = Int32.Parse(powerLevel!);

        return new Hero
        {
            Name = heroName!,
            PowerLevel = powerLevelInt
        };
    }

    public static string ShowRemoveHeroMenu()
    {
        System.Console.WriteLine("Enter the name of the hero you'd like to remove.");
        var input = Console.ReadLine();
        return input!;
    }

    private static void ShowInvalidInputMessage(string input)
    {
        Console.WriteLine($"Input {input} is invalid. Try again.");
    }
}