using System.Xml.Serialization;

namespace Sandwitch.Domain.ViewModels.Views;

/// <summary>
///     Represents a <see cref="ViewBase" /> class.
/// </summary>
public abstract class ViewBase
{
    /// <summary>
    ///     Gets or Sets <see cref="Id" />
    /// </summary>
    [XmlElement("id")]
    public int Id { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="LastModified" />
    /// </summary>
    [XmlElement("last-modified")]
    public DateTime LastModified { get; set; }
}