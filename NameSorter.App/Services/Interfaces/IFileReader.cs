namespace NameSorter.App.Services.Interfaces
{
    public interface IFileReader
    {
        List<string> ReadLines(string filePath);
    }
}
