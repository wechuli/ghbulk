using System.CommandLine;
using GhBulk.Commands;


namespace GhBulk;

internal class Program
{
    private static async Task<int> Main(string[] args)
    {

     return await GlobalCommand.Run(args);
    }

}

