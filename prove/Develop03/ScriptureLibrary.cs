// Class representing a library of scripts
class ScriptureLibrary
{
    private List<Scripture> scriptures;
    private Random random;

    public ScriptureLibrary(List<Scripture> scriptures)
    {
        this.scriptures = scriptures;
        random = new Random();
    }

    // Get a random write from the library
    public Scripture GetRandomScripture()
    {
        int index = random.Next(scriptures.Count);
        return scriptures[index];
    }
}