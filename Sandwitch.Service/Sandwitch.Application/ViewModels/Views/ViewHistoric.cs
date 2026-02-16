namespace Sandwitch.Application.ViewModels.Views;

/// <summary>
///     Represents a <see cref="ViewHistoric" /> class. Inherits <see cref="ViewBase" />
/// </summary>
public class ViewHistoric : ViewBase
{
    /// <summary>
    ///     Gets or Sets <see cref="Wind" />
    /// </summary>
    public virtual ViewCatalog Wind { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="Flag" />
    /// </summary>
    public virtual ViewCatalog Flag { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="Beach" />
    /// </summary>
    public virtual ViewCatalog Beach { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="Speed" />
    /// </summary>
    public double Speed { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="Temperature" />
    /// </summary>
    public double Temperature { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="LowSeaDawn" />
    /// </summary>
    public DateTime LowSeaDawn { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="LowSeaSunset" />
    /// </summary>
    public DateTime LowSeaSunset { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="HighSeaDawn" />
    /// </summary>
    public DateTime HighSeaDawn { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="HighSeaSunset" />
    /// </summary>
    public DateTime HighSeaSunset { get; set; }
}