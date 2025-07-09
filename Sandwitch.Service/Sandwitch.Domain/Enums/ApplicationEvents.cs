namespace Sandwitch.Domain.Enums;

/// <summary>
///     Represents a <see cref="ApplicationEvents" /> class
/// </summary>
public enum ApplicationEvents
{
    /// <summary>
    ///     Insert <see cref="ApplicationEvents" />
    /// </summary>
    InsertItem = 1,

    /// <summary>
    ///     Update <see cref="ApplicationEvents" />
    /// </summary>
    UpdateItem = 2,

    /// <summary>
    ///     Delete <see cref="ApplicationEvents" />
    /// </summary>
    DeleteItem = 3,

    /// <summary>
    ///     Not Found <see cref="ApplicationEvents" />
    /// </summary>
    GetItemNotFound = 4,

    /// <summary>
    ///     Found <see cref="ApplicationEvents" />
    /// </summary>
    GetItemFound = 5
}