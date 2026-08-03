using Microsoft.Extensions.DependencyInjection;

namespace Sandwitch.Infrastructure.Installers;

/// <summary>
///     Represents a <see cref="McpServerInstaller" /> class.
/// </summary>
public static class McpServerInstaller
{
    /// <summary>
    ///     Installs Mcp Server
    /// </summary>
    /// <param name="this">Injected <see cref="IServiceCollection" /></param>
    public static void InstallMcpServer(this IServiceCollection @this)
    {
        @this.AddMcpServer()
            .WithHttpTransport(options =>
            {
                options.Stateless = true;
            })
            .WithToolsFromAssembly();
    }
}