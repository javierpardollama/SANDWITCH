using NUnit.Framework;

using Sandwitch.Tier.Helpers.Classes;

using System.Collections.Generic;

namespace Sandwitch.Tier.Helpers.Test.Classes
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class SequenceHelperTest
    {
        [Test]
        public void When_Default_Sequence_Plus_Offset_Default_Then_GetNextAvailableNumber()
        {
            var given = new List<int>() { 0, 1 };

            var expected = 2;

            var result = SequenceHelper.GetNextAvailableNumber(given);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void When_Empty_Sequence_Plus_Offset_Default_Then_GetNextAvailableNumber()
        {
            var given = new List<int>() { };

            var expected = 0;

            var result = SequenceHelper.GetNextAvailableNumber(given);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void When_Null_Sequence_Plus_Offset_Default_Then_GetNextAvailableNumber()
        {
            List<int> given = null;

            var expected = 0;

            var result = SequenceHelper.GetNextAvailableNumber(given);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void When_Jump_Sequence_Plus_Offset_Default_Then_GetNextAvailableNumber()
        {
            var given = new List<int>() { 0, 1, 2, 6 };

            var expected = 3;

            var result = SequenceHelper.GetNextAvailableNumber(given);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void When_Default_Sequence_Plus_Offset_One_Then_GetNextAvailableNumber()
        {
            var given = new List<int>() { 0, 1 };

            var expected = 2;

            var result = SequenceHelper.GetNextAvailableNumber(given, 1);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void When_Empty_Sequence_Plus_Offset_One_Then_GetNextAvailableNumber()
        {
            var given = new List<int>() { };

            var expected = 1;

            var result = SequenceHelper.GetNextAvailableNumber(given, 1);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void When_Null_Sequence_Plus_Offset_One_Then_GetNextAvailableNumber()
        {
            List<int> given = null;

            var expected = 1;

            var result = SequenceHelper.GetNextAvailableNumber(given, 1);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void When_Jump_Sequence_Plus_Offset_One_Then_GetNextAvailableNumber()
        {
            var given = new List<int>() { 0, 1, 2, 6 };

            var expected = 3;

            var result = SequenceHelper.GetNextAvailableNumber(given, 1);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void When_Default_Sequence_Plus_Offset_Zero_Then_GetNextAvailableNumber()
        {
            var given = new List<int>() { 0, 1 };

            var expected = 2;

            var result = SequenceHelper.GetNextAvailableNumber(given, 0);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void When_Empty_Sequence_Plus_Offset_Zero_Then_GetNextAvailableNumber()
        {
            var given = new List<int>() { };

            var expected = 0;

            var result = SequenceHelper.GetNextAvailableNumber(given, 0);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void When_Null_Sequence_Plus_Offset_Zero_Then_GetNextAvailableNumber()
        {
            List<int> given = null;

            var expected = 0;

            var result = SequenceHelper.GetNextAvailableNumber(given, 0);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void When_Jump_Sequence_Plus_Offset_Zero_Then_GetNextAvailableNumber()
        {
            var given = new List<int>() { 0, 1, 2, 6 };

            var expected = 3;

            var result = SequenceHelper.GetNextAvailableNumber(given, 0);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
