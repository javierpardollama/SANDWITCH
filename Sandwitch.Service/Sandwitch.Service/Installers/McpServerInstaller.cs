namespace Sandwitch.Service.Installers;

/// <summary>
///     Represents a <see cref="McpServerInstaller" /> class.
/// </summary>
public static class McpServerInstaller
{
    /// <summary>
    ///     Installs Mcp Server
    /// </summary>
    /// <param name="this">Injected <see cref="IServiceCollection" /></param>
    public static void InstallMcpServer(this WebApplicationBuilder @this)
    {
        @this.Services.AddMcpServer()
            .WithHttpTransport(options =>
            {
                options.Stateless = true;
            })
            .AddAuthorizationFilters()
            .WithToolsFromAssembly();
    }
}