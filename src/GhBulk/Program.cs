using System.CommandLine;

namespace GhBulk;

class Program
{
    static async Task<int> Main(string[] args)
    {

        var rootCommand = new RootCommand("Command line tool for bulk Github operations");
        Console.WriteLine("Hello World!");

        return await rootCommand.InvokeAsync(args);
    }

}

