namespace GhBulk.Utils;

public static class EnvVars
{
    public static string Token
    {
        get
        {
            string GITHUB_TOKEN = Environment.GetEnvironmentVariable("GITHUB_TOKEN");
            string GH_TOKEN = Environment.GetEnvironmentVariable("GH_TOKEN");
            return GITHUB_TOKEN ?? GH_TOKEN ?? null;
        }
    }
    
    public static string Host
    {
        get
        {
            string apiUrl = Environment.GetEnvironmentVariable("GITHUB_API_URL");
            string ghHost = Environment.GetEnvironmentVariable("GITHUB_HOST");
            string host = Environment.GetEnvironmentVariable("HOST");
            return apiUrl ?? ghHost ?? host ?? "https://api.github.com";
        }
    }
    
}