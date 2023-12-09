
using GhBulk.Utils;
using GhBulk.Constants;


namespace GhBulk.Test.UtilsTests;


public class EnvVarsTests: IDisposable
{
    private readonly string _originalGH_TOKEN;
    private readonly string _originalGITHUB_TOKEN;
    private readonly string _originalGITHUB_API_URL;
    private readonly string _originalGITHUB_HOST;
    private readonly string _originalHOST;


    public EnvVarsTests()
    {
        _originalGH_TOKEN = Environment.GetEnvironmentVariable(AppConstants.GH_TOKEN.ToString());
        _originalGITHUB_TOKEN = Environment.GetEnvironmentVariable(AppConstants.GITHUB_TOKEN.ToString());
        _originalGITHUB_API_URL = Environment.GetEnvironmentVariable(AppConstants.GITHUB_API_URL.ToString());
        _originalGITHUB_HOST = Environment.GetEnvironmentVariable(AppConstants.GITHUB_HOST.ToString());
        _originalHOST = Environment.GetEnvironmentVariable(AppConstants.HOST.ToString());
    }
    [Fact]
    public void TokenShouldBeNullIfEnvVarsAreNotSet()
    {
        Environment.SetEnvironmentVariable(AppConstants.GH_TOKEN.ToString(), null);
        Environment.SetEnvironmentVariable(AppConstants.GITHUB_TOKEN.ToString(), null);
        Assert.Null(EnvVars.Token);
    }

    [Fact]
    public void TokenShouldBeGH_TOKENIfOnlyThatIsSet()
    {
        string token = "ghs_FNckq5feQFY1inZAX8edj2qwCdYRyQ2r8YzM";
        Environment.SetEnvironmentVariable(AppConstants.GH_TOKEN.ToString(),token);
        Environment.SetEnvironmentVariable(AppConstants.GITHUB_TOKEN.ToString(), null);
        
        Assert.Equal(token, EnvVars.Token);
    }

    [Fact]
    public void TokenShouldBeGITHUB_TOKENIfOnlyThatIsSet()
    {
        string token = "ghs_FNckq5feQFY1inZAX8edj2qwCdYRyQ2r8YzM";
        Environment.SetEnvironmentVariable(AppConstants.GITHUB_TOKEN.ToString(),token);
        Environment.SetEnvironmentVariable(AppConstants.GH_TOKEN.ToString(),null);
        
        Assert.Equal(token,EnvVars.Token);
    }

    [Fact]
    public void PreferGITHUB_TOKENIfGH_TOKENIsAlsoSet()
    {
        string gh_token = "ghs_FNckq5feQFY1inZA1234j2qwCdYRyQ2r8YzA";
        string github_token = "ghs_9Nckp4dePFY2hmZBX567ej3rxBeZRzR3s9XyB";
        
        Environment.SetEnvironmentVariable(AppConstants.GH_TOKEN.ToString(),gh_token);
        Environment.SetEnvironmentVariable(AppConstants.GITHUB_TOKEN.ToString(),github_token);
        Assert.Equal(github_token,EnvVars.Token);
        

    }
    
    [Fact]
    public void HostShouldBeGITHUB_API_URLIfOnlyThatIsSet()
    {
        string apiUrl = "https://github.example.com";
        Environment.SetEnvironmentVariable(AppConstants.GITHUB_API_URL.ToString(),apiUrl);
        Environment.SetEnvironmentVariable(AppConstants.GITHUB_HOST.ToString(), null);
        Environment.SetEnvironmentVariable(AppConstants.HOST.ToString(), null);
        
        Assert.Equal(apiUrl,EnvVars.Host);
    }
    
    [Fact]
    public void HostShouldBeGITHUB_HOSTIfOnlyThatIsSet()
    {
        string ghHost = "https://github.example.com";
        Environment.SetEnvironmentVariable(AppConstants.GITHUB_HOST.ToString(),ghHost);
        Environment.SetEnvironmentVariable(AppConstants.GITHUB_API_URL.ToString(), null);
        Environment.SetEnvironmentVariable(AppConstants.HOST.ToString(), null);
        
        Assert.Equal(ghHost,EnvVars.Host);
    }
    
    [Fact]
    public void HostShouldBeHOSTIfOnlyThatIsSet()
    {
        string host = "https://github.example.com";
        Environment.SetEnvironmentVariable(AppConstants.HOST.ToString(),host);
        Environment.SetEnvironmentVariable(AppConstants.GITHUB_API_URL.ToString(), null);
        Environment.SetEnvironmentVariable(AppConstants.GITHUB_HOST.ToString(), null);
        
        Assert.Equal(host,EnvVars.Host);
    }
    
    [Fact]
    public void PreferGITHUB_API_URLIfGITHUB_HOSTIsAlsoSet()
    {
        string ghHost = "https://github.example.com";
        string apiUrl = "https://github.example.com";
        
        Environment.SetEnvironmentVariable(AppConstants.GITHUB_HOST.ToString(),ghHost);
        Environment.SetEnvironmentVariable(AppConstants.GITHUB_API_URL.ToString(),apiUrl);
        Assert.Equal(apiUrl,EnvVars.Host);
        

    }
    
    [Fact]
    public void PreferGITHUB_API_URLIfHOSTIsAlsoSet()
    {
        string host = "https://github.example.com";
        string apiUrl = "https://github.example.com";
        
        Environment.SetEnvironmentVariable(AppConstants.HOST.ToString(),host);
        Environment.SetEnvironmentVariable(AppConstants.GITHUB_API_URL.ToString(),apiUrl);
        Assert.Equal(apiUrl,EnvVars.Host);
        

    }
    
    [Fact]
    public void PreferGITHUB_HOSTIfHOSTIsAlsoSet()
    {
        string host = "https://github.example.com";
        string ghHost = "https://github.example.com";
        
        Environment.SetEnvironmentVariable(AppConstants.HOST.ToString(),host);
        Environment.SetEnvironmentVariable(AppConstants.GITHUB_HOST.ToString(),ghHost);
        Assert.Equal(ghHost,EnvVars.Host);
        

    }
    
    [Fact]
    public void ReturnGitHubDotComIfNoHostIsSet()
    {
        Environment.SetEnvironmentVariable(AppConstants.HOST.ToString(),null);
        Environment.SetEnvironmentVariable(AppConstants.GITHUB_HOST.ToString(),null);
        Environment.SetEnvironmentVariable(AppConstants.GITHUB_API_URL.ToString(),null);
        Assert.Equal("https://api.github.com",EnvVars.Host);
    }
    
    public void Dispose()
    {
        Environment.SetEnvironmentVariable(AppConstants.GH_TOKEN.ToString(), _originalGH_TOKEN);
        Environment.SetEnvironmentVariable(AppConstants.GITHUB_TOKEN.ToString(), _originalGITHUB_TOKEN);
        Environment.SetEnvironmentVariable(AppConstants.GITHUB_API_URL.ToString(), _originalGITHUB_API_URL);
        Environment.SetEnvironmentVariable(AppConstants.GITHUB_HOST.ToString(), _originalGITHUB_HOST);
        Environment.SetEnvironmentVariable(AppConstants.HOST.ToString(), _originalHOST);
    }
}
