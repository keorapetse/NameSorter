using NameSorter.App.Models;
using NameSorter.App.Services;
using NameSorter.App.Services.Interfaces;

class Program
{
    static void Main(string[] args)
    {
        // file path of unsorted-names-list.txt
        string inputFilePath = GetInputFilePath(args);

        // check if unsorted-names-list.txt exists in directory
        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine($"Error: File '{inputFilePath}' not found.");
            return;
        }

        // directory for sorted-names-list.txt
        string outputFilePath = GetOutputFilePath(inputFilePath);

        // read names from unsorted-names-list.txt file
        var names = ReadNamesFromFile(inputFilePath);

        // method to sort the names
        var sortedNames = SortNames(names);

        // prints sorted names to console
        PrintNamesToConsole(sortedNames);

        // write sorted names to sorted-names-list.txt file
        WriteNamesToFile(outputFilePath, sortedNames);

        // directory for sorted-names-list.txt
        Console.WriteLine($"Sorted names written to the Desktop: {outputFilePath}");
    }

    // the directory for the unsorted-names-list.txt file
    static string GetInputFilePath(string[] args)
    {
        if (args.Length == 0)
        {
            var defaultPath = Path.Combine(AppContext.BaseDirectory, "unsorted-names-list.txt");
            return defaultPath;
        }

        return args[0];
    }

    // the directory of the sorted-names-list.txt file
    static string GetOutputFilePath(string inputFilePath)
    {
        // Get the current user's desktop folder
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        // Combine desktop folder path with the file name
        return Path.Combine(desktopPath, "sorted-names-list.txt");
    }

    // Reads names from file and converts them into PersonName objects.
    static List<PersonName> ReadNamesFromFile(string inputFilePath)
    {
        IFileReader reader = new FileReader(); // use FileReader to read data from text file
        var lines = reader.ReadLines(inputFilePath); // read lines from the unsorted-names-list.txt file

        return lines
            .Where(line => !string.IsNullOrWhiteSpace(line)) // skip empty lines
            .Select(line =>
            {
                var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries); // split last name and given names
                var lastName = parts[^1]; // last name
                var givenNames = parts.Take(parts.Length - 1).ToList(); // takes all elements except the last as the given names
                return new PersonName { LastName = lastName, GivenNames = givenNames };
            })
            .ToList();
    }

    // Sorts names by last name and then given names.
    static List<PersonName> SortNames(List<PersonName> names)
    {
        INameSorter sorter = new NameSorterService();
        return sorter.SortNames(names);
    }

    // Prints the sorted names to the console.
    static void PrintNamesToConsole(List<PersonName> names)
    {
        Console.WriteLine("Sorted names:");
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }

    // Writes the sorted names to a file.
    static void WriteNamesToFile(string outputFilePath, List<PersonName> names)
    {
        IFileWriter writer = new FileWriter();
        writer.WriteLines(outputFilePath, names.Select(n => n.ToString()));
    }
}