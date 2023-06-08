using System.Collections.Generic;
using System.Linq;

namespace Sandwitch.Tier.Helpers.Classes
{
    /// <summary>
    /// Represents a <see cref="SequenceHelper"/> class.
    /// </summary>
    public static class SequenceHelper
    {
        /// <summary>
        /// Gets Next Available Number
        /// </summary>
        /// <param name="sequence">Injected <see cref="IReadOnlyCollection{int}"/></param>
        /// <param name="offset">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="int"/></returns>
        public static int GetNextAvailableNumber(IReadOnlyCollection<int> @sequence, int @offset = 0)
        {
            if (@sequence == null || !@sequence.Any())
            {
                return @offset;
            }

            var @ordered = @sequence.OrderBy(s => s).ToList();

            var @losts = Enumerable.Range(offset, @ordered.Last()).Except(@ordered).ToList();

            if (@losts.Any())
            {
                return @losts.First();
            }
            else
            {
                return @ordered.Last() + 1;
            }
        }
    }
}
