using Newtonsoft.Json;

namespace HeroesCreator;

public class HeroClient
{
    private readonly FileClient _fileClient;

    public HeroClient(FileClient fileClient)
    {
        _fileClient = fileClient;
    }

    public IEnumerable<Hero> GetHeroes()
    {
        var saveFile = _fileClient.Read();
        var heroes = Enumerable.Empty<Hero>();
        try
        {
            heroes = JsonConvert.DeserializeObject<IEnumerable<Hero>>(saveFile)!;
        }
        catch (System.Exception)
        {
            throw;
        }

        return heroes;
    }

    public Hero? GetHeroByName(string name)
    {
        return GetHeroes()?.FirstOrDefault(hero => hero.Name == name);
    }

    public void AddHero(Hero hero)
    {
        var heroes = GetHeroes()?.ToList() ?? new List<Hero>();
        heroes.Add(hero);

        System.Console.WriteLine();
        Console.WriteLine($"Added hero {hero.Name}");

        SaveHeroes(heroes);
    }

    public void SaveHeroes(IEnumerable<Hero> heroes)
    {
        var jsonString = JsonConvert.SerializeObject(heroes);
        _fileClient.Write(jsonString);
    }

    public void RemoveHero(Hero heroToRemove)
    {
        var heroes = GetHeroes()?.ToList() ?? new List<Hero>();

        heroes?.RemoveAll(hero => hero.Name == heroToRemove.Name);

        System.Console.WriteLine();
        Console.WriteLine($"Removed hero {heroToRemove.Name}");

        SaveHeroes(heroes!);
    }

    public void RemoveHeroByName(string heroName)
    {
        var heroes = GetHeroes()?.ToList() ?? new List<Hero>();

        heroes?.RemoveAll(hero => hero.Name == heroName);

        System.Console.WriteLine();
        Console.WriteLine($"Removed hero {heroName}");

        SaveHeroes(heroes!);
    }
}