using System.CommandLine;
using GhBulk.Utils;

namespace GhBulk.Commands;

public static class GlobalCommand
{
    
    public static async  Task<int> Run(string[] args)
    {
        var rootCommand = new RootCommand("Command line tool for bulk GitHub operations");
        var tokenOption = new Option<string>(
            name:"--token",
            description: "Token to use for authentication, optional if GITHUB_TOKEN or GH_TOKEN environment variable is set",
            isDefault:true,
            parseArgument: result =>
            {
                // check if a value was provided in the command line and its not an empty string
                if (result.Tokens.Count > 0 && !string.IsNullOrWhiteSpace(result.Tokens[0].Value))
                {
                    return result.Tokens[0].Value;
                }
                
                // check if a value was provided in the environment variable
                if (!string.IsNullOrWhiteSpace(EnvVars.Token))
                {
                    return EnvVars.Token;
                }
                result.ErrorMessage = "An authentication token is required";
                return null;
            }
            );
        rootCommand.AddOption(tokenOption);

        return await rootCommand.InvokeAsync(args);
    }
    
}