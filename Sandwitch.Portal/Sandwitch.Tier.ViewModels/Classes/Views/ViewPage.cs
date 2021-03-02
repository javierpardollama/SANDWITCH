﻿using System.Collections.Generic;

namespace Sandwitch.Tier.ViewModels.Classes.Views
{
    /// <summary>
    /// Represents a <see cref="ViewPage{T}"/> class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ViewPage<T> 
    {
        /// <summary>
        /// Gets or Sets <see cref="Count"/>
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Index"/>
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Size"/>
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Items"/>
        /// </summary>
        public ICollection<T> Items { get; set; }
    }
}
