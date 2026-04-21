using System.Runtime.Serialization;

namespace Sandwitch.Domain.Enums;

/// <summary>
///     Represents a <see cref="WindIdentifiers" /> class
/// </summary>
public enum WindIdentifiers
{
    /// <summary>
    ///     Norte <see cref="WindIdentifiers" />
    /// </summary>
    [EnumMember]
    Norte = 1,

    /// <summary>
    ///     Noroeste <see cref="WindIdentifiers" />
    /// </summary>
    [EnumMember]
    Noroeste = 2,

    /// <summary>
    ///     Oeste <see cref="WindIdentifiers" />
    /// </summary>
    [EnumMember]
    Oeste = 3,

    /// <summary>
    ///     Sudoeste <see cref="WindIdentifiers" />
    /// </summary>
    [EnumMember]
    Sudoeste = 4,

    /// <summary>
    ///     Sur <see cref="WindIdentifiers" />
    /// </summary>
    [EnumMember]
    Sur = 5,

    /// <summary>
    ///     Sudeste <see cref="WindIdentifiers" />
    /// </summary>
    [EnumMember]
    Sudeste = 6,

    /// <summary>
    ///     Este <see cref="WindIdentifiers" />
    /// </summary>
    [EnumMember]
    Este = 7,

    /// <summary>
    ///     Noreste <see cref="WindIdentifiers" />
    /// </summary>
    [EnumMember]
    Noreste = 8
}