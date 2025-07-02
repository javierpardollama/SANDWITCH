using System.Xml.Serialization;

namespace Sandwitch.Tier.ViewModels.Classes.Views;

/// <summary>
/// Represents a <see cref="ViewBuscador"/> class. Inherits <see cref="ViewBase"/>
/// </summary>
[XmlRoot("buscador")]
public class ViewBuscador : ViewBase
{
    /// <summary>
    /// Gets or Sets <see cref="Name"/>
    /// </summary>
    [XmlElement("name")]
    public string Name { get; set; }
    
    /// <summary>
    /// Gets or Sets <see cref="ImageUri"/>
    /// </summary>
    [XmlElement("image-uri")]
    public string ImageUri { get; set; }
    
    /// <summary>
    /// Gets or Sets <see cref="Type"/>
    /// </summary>
    [XmlElement("type")]
    public string Type { get; set; }
}