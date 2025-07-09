using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Sandwitch.Domain.Settings;
using Sandwitch.Infrastructure.Contexts;
using Sandwitch.Infrastructure.Interceptors;

namespace Sandwitch.Test.Infrastructure.Managers;

/// <summary>
///     Represents a <see cref="BaseManagerTest" /> class.
/// </summary>
public abstract class BaseManagerTest
{
    /// <summary>
    ///     Gets or Sets <see cref="IOptions{ApiSettings}" />
    /// </summary>
    protected IOptions<ApiSettings> ApiOptions { get; set; } = Options.Create(new ApiSettings
    {
        ApiLock = "Pauline",
        ApiKey = "T/R4J6eyvNG<6ne!"
    });

    /// <summary>
    ///     Gets or Sets <see cref="ApplicationContext" />
    /// </summary>
    protected ApplicationContext Context { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="DbContextOptionsBuilder{ApplicationContext}" />
    /// </summary>
    protected DbContextOptionsBuilder<ApplicationContext> ContextOptionsBuilder { get; set; } =
        new DbContextOptionsBuilder<ApplicationContext>()
            .UseInMemoryDatabase("sandwitch.db")
            .AddInterceptors(new SoftDeleteInterceptor());

    /// <summary>
    ///     Sets Up Context
    /// </summary>
    protected void SetUpContext()
    {
        Context = new ApplicationContext(ContextOptionsBuilder.Options);
    }
}