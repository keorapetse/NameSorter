namespace NameSorter.App.Services.Interfaces
{
    public interface IFileWriter
    {
        void WriteLines(string filePath, IEnumerable<string> lines);
    }
}
