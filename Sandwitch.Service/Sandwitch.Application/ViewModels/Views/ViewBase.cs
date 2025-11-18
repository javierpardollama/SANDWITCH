namespace Sandwitch.Application.ViewModels.Views;

/// <summary>
///     Represents a <see cref="ViewBase" /> class.
/// </summary>
public abstract class ViewBase
{
    /// <summary>
    ///     Gets or Sets <see cref="Id" />
    /// </summary>  
    public int Id { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="LastModified" />
    /// </summary>   
    public DateTime? LastModified { get; set; }
}