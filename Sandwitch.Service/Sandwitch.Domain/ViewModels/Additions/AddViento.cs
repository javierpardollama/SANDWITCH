﻿using System.ComponentModel.DataAnnotations;

namespace Sandwitch.Domain.ViewModels.Additions;

/// <summary>
///     Represents a <see cref="AddViento" /> class.
/// </summary>
public class AddViento
{
    /// <summary>
    ///     Initializes a new Instance of <see cref="AddViento" />
    /// </summary>
    public AddViento()
    {
    }

    /// <summary>
    ///     Gets or Sets <see cref="Name" />
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="ImageUri" />
    /// </summary>
    [Required]
    [Url]
    public string ImageUri { get; set; }
}