namespace Sandwitch.Domain.Dtos;

/// <summary>
/// Represents a <see cref="BeachDto"/> class.
/// </summary>
public class BeachDto
{
    /// <summary>
    /// Gets or Sets <see cref="Id"/>
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or Sets <see cref="LastModified"/>
    /// </summary>
    public DateTime? LastModified { get; set; }

    /// <summary>
    /// Gets or Sets <see cref="Name"/>
    /// </summary>
    public string Name { get; set; }        

    /// <summary>
    /// Gets or Sets <see cref="Townes"/>
    /// </summary>
    public virtual ICollection<CatalogDto> Towns { get; set; } = [];

    /// <summary>
    /// Gets or Sets <see cref="LastHistoric"/>
    /// </summary>
    public virtual HistoricDto LastHistoric { get; set; }
}
