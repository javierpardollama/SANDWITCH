using System.Xml.Serialization;

namespace Sandwitch.Domain.ViewModels.Views;

/// <summary>
///     Represents a <see cref="ViewBandera" /> class. Inherits <see cref="ViewBase" />
/// </summary>
[XmlRoot("bandera")]
public class ViewBandera : ViewBase
{
    /// <summary>
    ///     Initializes a new Instance of <see cref="ViewBandera" />
    /// </summary>
    public ViewBandera()
    {
    }

    /// <summary>
    ///     Gets or Sets <see cref="ImageUri" />
    /// </summary>
    [XmlElement("image-uri")]
    public string ImageUri { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="Name" />
    /// </summary>
    [XmlElement("name")]
    public string Name { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="Historicos" />
    /// </summary>
    [XmlArray("historicos")]
    public virtual IList<ViewHistorico> Historicos { get; set; }
}