using NameSorter.App.Models;
using NameSorter.App.Services;
using NameSorter.App.Services.Interfaces;

class Program
{
    static void Main(string[] args)
    {
        string inputFilePath;

        if (args.Length == 0)
        {
            inputFilePath = Path.Combine(AppContext.BaseDirectory, "unsorted-names-list.txt");
            Console.WriteLine($"No input argument provided. Using default file: {inputFilePath}");
        }
        else
        {
            inputFilePath = args[0];
        }

        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine($"Error: File '{inputFilePath}' not found.");
            return;
        }

        string outputFilePath = Path.Combine(Path.GetDirectoryName(inputFilePath) ?? AppContext.BaseDirectory, "sorted-names-list.txt");

        // Read names
        IFileReader reader = new FileReader();
        var lines = reader.ReadLines(inputFilePath);

        // Convert to PersonName objects
        var names = lines.Select(line =>
        {
            var parts = line.Split(' ');
            var lastName = parts[^1]; // last element
            var givenNames = parts.Take(parts.Length - 1).ToList();
            return new PersonName { LastName = lastName, GivenNames = givenNames };
        }).ToList();

        // Sort names
        INameSorter sorter = new NameSorterService();
        var sortedNames = sorter.SortNames(names);

        // Print to console
        Console.WriteLine("Sorted names:");
        foreach (var name in sortedNames)
        {
            Console.WriteLine(name);
        }

        // Write to file
        IFileWriter writer = new FileWriter();
        writer.WriteLines(outputFilePath, sortedNames.Select(n => n.ToString()));

        Console.WriteLine($"Sorted names written to: {outputFilePath}");
    }
}
