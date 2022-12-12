
using HeroesCreator;

var fileClient = new FileClient("./heroes.json");
var heroClient = new HeroClient(fileClient);

var superman = new Hero
{
    Name = "Superman",
    PowerLevel = 100
};

var batman = new Hero
{
    Name = "Batman",
    PowerLevel = 20
};

heroClient.AddHero(superman);
heroClient.AddHero(batman);

var applicationInProgress = true;

while (applicationInProgress)
{
    var showMainMenu = true;
    var showAddHeroMenu = false;
    var showRemoveHeroMenu = false;
    var listOutHeroes = false;

    while (showMainMenu)
    {
        var mainMenuResult = UserInterface.ShowMainMenu();

        if (mainMenuResult == MainMenuResult.Quit)
        {
            applicationInProgress = false;
            showMainMenu = false;
        }

        if (mainMenuResult == MainMenuResult.AddHero)
        {
            showAddHeroMenu = true;
            showMainMenu = false;
        }
        else if (mainMenuResult == MainMenuResult.RemoveHero)
        {
            showRemoveHeroMenu = true;
            showMainMenu = false;
        }
        else if (mainMenuResult == MainMenuResult.ListOutHeroes)
        {
            listOutHeroes = true;
            showMainMenu = false;
        }
    }

    while (showAddHeroMenu)
    {
        var hero = UserInterface.ShowAddHeroMenu();
        heroClient.AddHero(hero);
        System.Console.WriteLine();
        showAddHeroMenu = false;
    }

    while (showRemoveHeroMenu)
    {
        var heroName = UserInterface.ShowRemoveHeroMenu();
        heroClient.RemoveHeroByName(heroName);
        showRemoveHeroMenu = false;
    }

    while (listOutHeroes)
    {
        var heroes = heroClient.GetHeroes();
        Console.WriteLine($"listing out heroes. Length: {heroes.Count()}");
        Console.WriteLine();
        foreach (var hero in heroes)
        {
            Console.WriteLine($"Name: {hero.Name}; Powerlevel: {hero.PowerLevel}");
            System.Console.WriteLine();
        }
        listOutHeroes = false;
    }
}

Console.WriteLine("Quitting...");

