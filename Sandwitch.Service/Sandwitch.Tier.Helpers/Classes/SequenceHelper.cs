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
        /// <returns>Instance of <see cref="int"/></returns>
        public static int GetNextAvailableNumber(IReadOnlyCollection<int> sequence, int offset = 0)
        {
            // If the list is null or empty, returns the default offset (this uses 0, modify as needed) + 1
            if (sequence == null)
            {
                return offset + 1;
            }

            // Orders the values ascending
            var vals = sequence.OrderBy(s => s).ToList();

            // Finds the first value where Sequence Number is different from (index + 1)
            var firstGap = vals.TakeWhile((s, idx) => s == idx + 1).Count();

            // Takes the Sequence Number from the previous item and increment
            if (firstGap > 0)
            {
                return vals[firstGap - 1] + 1;
            }
            else
            {
                return 1;
            }
        }
    }
}
