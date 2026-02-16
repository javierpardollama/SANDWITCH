namespace Sandwitch.Domain.Dtos;

/// <summary>
/// Represents a <see cref="HistoricDto"/> class.
/// </summary>
public class HistoricDto
{
    /// <summary>
    ///     Gets or Sets <see cref="Id" />
    /// </summary>      
    public int Id { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="LastModified" />
    /// </summary>    
    public DateTime? LastModified { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="Wind" />
    /// </summary>      
    public virtual CatalogDto Wind { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="Flag" />
    /// </summary>       
    public virtual CatalogDto Flag { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="Beach" />
    /// </summary>       
    public virtual CatalogDto Beach { get; set; }

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
