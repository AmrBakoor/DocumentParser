using System;
using DocumentParser.BL.ConcreteProducts;
using FluentAssertions;

namespace ParserDocument.Test.BLTests
{
    [TestClass]
    public class SorterTests
    {
        private Sorter sorter;

        [TestInitialize]
        public void TestInitialize()
        {
            sorter = new Sorter();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Sort_NullDictionary_ThrowsArgumentNullException()
        {
            // Arrange
            Dictionary<string, int> dictionary = null;

            // Act & Assert
            sorter.Sort(dictionary);
        }

        [TestMethod]
        public void Sort_EmptyDictionary_ReturnsEmptyDictionary()
        {
            // Arrange
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            // Act
            Dictionary<string, int> result = sorter.Sort(dictionary);

            // Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(0);
        }

        [TestMethod]
        public void Sort_SingleElementDictionary_ReturnsDictionaryWithSingleElement()
        {
            // Arrange
            Dictionary<string, int> dictionary = new Dictionary<string, int>() { { "a", 1 } };

            // Act
            Dictionary<string, int> result = sorter.Sort(dictionary);

            // Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(1);
            result.Keys.ToArray()[0].Should().Be("a");
            result["a"].Should().Be(1);
        }

        [TestMethod]
        public void Sort_MultiElementDictionary_ReturnsSortedDictionary()
        {
            // Arrange
            Dictionary<string, int> dictionary = new Dictionary<string, int>()
        {
            { "Hello", 2 },
            { "ik", 1 },
            { "ben", 4 },
            { "Amr", 3 }
        };

            // Act
            Dictionary<string, int> result = sorter.Sort(dictionary);

            // Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(4);
            result.Keys.ToArray()[0].Should().Be("Amr");
            result.Keys.ToArray()[1].Should().Be("ben");
            result.Keys.ToArray()[2].Should().Be("Hello");
            result.Keys.ToArray()[3].Should().Be("ik");
        }
    }
}

