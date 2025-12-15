namespace Sandwitch.Domain.Dtos;

/// <summary>
/// Represents a <see cref="BuscadorDto"/> class.
/// </summary>
public class BuscadorDto
{
    /// <summary>
    ///     Gets or Sets <see cref="Id" />
    /// </summary>      
    public int Id { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="Name" />
    /// </summary>        
    public string Name { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="ImageUri" />
    /// </summary>       
    public string ImageUri { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="Group" />
    /// </summary>       
    public string Group { get; set; }
}
