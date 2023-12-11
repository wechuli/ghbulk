using System.CommandLine;
using GhBulk.Utils;
using GhBulk.Constants;

namespace GhBulk.Commands;

public static class GlobalCommand
{
    public static string Token { get; private set; }
    public static async  Task<int> Run(string[] args)
    {
        var rootCommand = new RootCommand("Command line tool for bulk GitHub operations");
        var tokenOption = new Option<string>(
            name:"--token",
            description: "Token to use for authentication, optional if GITHUB_TOKEN or GH_TOKEN environment variable is",
            isDefault:true,
            parseArgument: result =>
            {
                // check if a value was provided in the command line and its not an empty string
                if (result.Tokens.Count > 0 && !string.IsNullOrWhiteSpace(result.Tokens[0].Value))
                { 
                    Token = result.Tokens[0].Value;
                    return Token;
                }
                
                // check if a value was provided in the environment variable
                if (!string.IsNullOrWhiteSpace(EnvVars.Token))
                {
                    Token = EnvVars.Token;
                    return Token;
                }
                result.ErrorMessage = ValidationErrors.TokenNotProvided;
                return null;
            }
            );
        
        tokenOption.AddAlias("-t");
        rootCommand.AddOption(tokenOption);

        return await rootCommand.InvokeAsync(args);
    }
    
}