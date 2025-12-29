namespace Sandwitch.Domain.Dtos;

/// <summary>
/// Represents a <see cref="WindDto"/> class.
/// </summary>
public class WindDto
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
    /// Gets or Sets <see cref="ImageUri"/>
    /// </summary>
    public string ImageUri { get; set; }
}
