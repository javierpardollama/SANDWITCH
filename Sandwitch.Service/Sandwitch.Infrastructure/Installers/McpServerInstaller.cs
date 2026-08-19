using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ModelContextProtocol.Server;

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
    public static void InstallMcpServer(this WebApplicationBuilder @this)
    {
        @this.Services.AddMcpServer()
            .WithHttpTransport(options =>
            {
                options.Stateless = true;
            })
            .AddAuthorizationFilters()
            .MapMcpTools();
    }

    /// <summary>
    /// Maps Mcp Tools
    /// </summary>
    /// <param name="builder">Injected <see cref="IMcpServerBuilder" /></param>
    /// <returns>Instance of <see cref="IMcpServerBuilder"/></returns>
    private static void MapMcpTools(this IMcpServerBuilder @builder)
    {
        var @assemblies = AppDomain.CurrentDomain
            .GetAssemblies()
            .Where(a => a.GetTypes()
                .Any(t => t.GetCustomAttributes(typeof(McpServerToolTypeAttribute), inherit: true)
                    .Any()
            ));
        
        foreach (var @assembly in @assemblies)
        {
            @builder.WithToolsFromAssembly(@assembly);
        }
    }
}