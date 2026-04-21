using System.Runtime.Serialization;

namespace Sandwitch.Domain.Enums;

/// <summary>
///     Represents a <see cref="FlagIdentifiers" /> class
/// </summary>
public enum FlagIdentifiers
{
    /// <summary>
    ///     Amarilla <see cref="FlagIdentifiers" />
    /// </summary>
    [EnumMember]
    Amarilla = 1,

    /// <summary>
    ///     Negra <see cref="FlagIdentifiers" />
    /// </summary>
    [EnumMember]
    Negra = 2,

    /// <summary>
    ///     Roja <see cref="FlagIdentifiers" />
    /// </summary>
    [EnumMember]
    Roja = 3,

    /// <summary>
    ///     Verde <see cref="FlagIdentifiers" />
    /// </summary>
    [EnumMember]
    Verde = 4,

    /// <summary>
    ///     Violeta <see cref="FlagIdentifiers" />
    /// </summary>
    [EnumMember]
    Violeta = 5
}