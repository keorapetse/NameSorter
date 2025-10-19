using NameSorter.App.Services.Interfaces;

namespace NameSorter.App.Services
{
    public class FileWriter : IFileWriter
    {
        public void WriteLines (string filePath, IEnumerable<string> lines)
        {
            File.WriteAllLines(filePath, lines);
        }
    }
}
