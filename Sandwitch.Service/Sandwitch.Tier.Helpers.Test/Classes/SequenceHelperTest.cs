using NUnit.Framework;

using Sandwitch.Tier.Helpers.Classes;

using System.Collections.Generic;
using System.Linq;

namespace Sandwitch.Tier.Helpers.Test.Classes
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class SequenceHelperTest
    {
        [Test]
        [TestCase(new object[] { 0, 1 }, 2)]
        [TestCase(new object[] { 0 }, 1)]
        [TestCase(new object[] { }, 0)]       
        [TestCase(new object[] { 0, 1, 2, 6 }, 3)]     
        public void GetNextAvailableNumber(object[] given, int expected)
        {
            var result = SequenceHelper.GetNextAvailableNumber(given.Cast<int>().ToList());

            Assert.That(result, Is.EqualTo(expected));
        }      
    }
}
