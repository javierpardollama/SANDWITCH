namespace Sandwitch.Domain.Entities;

/// <summary>
///     Represents a <see cref="Page{T}" /> class.
/// </summary>
/// <typeparam name="T"></typeparam>
public class Page<T>
{
        /// <summary>
        ///     Gets or Sets <see cref="Length" />
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        ///     Gets or Sets <see cref="Index" />
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        ///     Gets or Sets <see cref="Size" />
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        ///     Gets or Sets <see cref="Items" />
        /// </summary>
        public ICollection<T> Items { get; set; }
}