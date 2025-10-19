using NameSorter.App.Services.Interfaces;

namespace NameSorter.App.Services
{
    public class FileReader : IFileReader
    {
        public List<string> ReadLines (string filePath)
        {
            return File.ReadAllLines(filePath).ToList();
        }
    }
}
