namespace HeroesCreator;

public class FileClient
{
    private readonly string _filePath;

    public FileClient(string filePath)
    {
        _filePath = filePath;
    }

    public void Write(string content)
    {
        var fileWriter = new StreamWriter(_filePath);

        fileWriter.Write(content);
        fileWriter.Dispose();
    }

    public string Read()
    {
        var reader = new StreamReader(_filePath);
        var content = reader.ReadToEnd();
        reader.Dispose();
        return content;
    }
}