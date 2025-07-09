using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sandwitch.Domain.Entities.Interfaces;

/// <summary>
///     Represents a <see cref="IBase" /> interface
/// </summary>
public interface IBase
{
    /// <summary>
    ///     Gets or Sets <see cref="Id" />
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    public int Id { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="LastModified" />
    /// </summary>
    [Required]
    public DateTime LastModified { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="Deleted" />
    /// </summary>
    [Required]
    public bool Deleted { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="Version" />
    /// </summary>
    [Timestamp]
    [ConcurrencyCheck]
    public byte[] Version { get; set; }
}