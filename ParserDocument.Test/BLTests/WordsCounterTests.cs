using System;
using DocumentParser.Domain;
using DocumentParser.BL.ConcreteProducts;
using DocumentParser.BL.AbstractProducts;
using FluentAssertions;
using DocumentParser.Domain.ConcreteProducts;

namespace ParserDocument.Test.BLTests
{
	[TestClass]
	public class WordsCounterTests
	{
        private WordsCounter _wordsCounter;

        [TestInitialize]
        public void TestInitialize()
        {
            _wordsCounter = new WordsCounter();
        }

        [TestMethod]
        public void Parse_ReturnsExpectedWordOccurrences_WhenValidDocumentIsProvided()
        {
            // Arrange
            var document = new Document(@"Hoi IK heet Document Parser app.ik was door mijn vriend AMR ontwikkled. De ontwikkleing was om 19:30 uur 20 maart begonnen. amr gebruikte TDD die ik van het houd.
                                         Ik hoop dat jullie me  mooi gaan vinden.Amr spreekt Nederlands.");

            var expectedWordOccurrences = new Dictionary<string, int>

            {
                { "amr", 3 },
                { "app", 1 },
                { "begonnen", 1 },
                { "dat", 1 },
                { "de", 1 },
                { "die", 1 },
                { "document", 1 },
                { "door", 1 },
                { "gaan", 1 },
                { "gebruikte", 1 },
                { "heet", 1 },
                { "het", 1 },
                { "hoi", 1 },
                { "hoop", 1 },
                { "houd", 1 },
                { "ik", 4 },
                { "jullie", 1 },
                { "maart" , 1 },
                { "me",  1 },
                { "mijn", 1 },
                {"mooi", 1 },
                {"nederlands", 1 },
                {"om",  1 },
                { "ontwikkled",  1 },
                { "ontwikkleing", 1 },
                { "parser",  1 },
                {"spreekt", 1 },
                { "tdd", 1 },
                { "uur", 1 },
                { "van", 1 },
                { "vinden",  1 },
                {"vriend",  1 },
                {"was", 2 }
            };

            // Act
            var actualWordOccurrences = _wordsCounter.Count(document);

            // Assert
            actualWordOccurrences.Should().BeEquivalentTo(expectedWordOccurrences);
        }

       
        [TestMethod]
        public void Count_ReturnsEmptyDictionary_WhenDocumentIsEmpty()
        {
            // Arrange
            var document = new Document("");
            var expectedWordOccurrences = new Dictionary<string, int>();

            // Act
            var actualWordOccurrences = _wordsCounter.Count(document);

            // Assert
            CollectionAssert.AreEqual(expectedWordOccurrences, actualWordOccurrences);
        }

        [TestMethod]
        public void Count_ReturnsEmptyDictionary_WhenDocumentContainsOnlyNumbers()
        {
            // Arrange
            var document = new Document("123 456 789");
            var expectedWordOccurrences = new Dictionary<string, int>();

            // Act
            var actualWordOccurrences = _wordsCounter.Count(document);

            // Assert
            CollectionAssert.AreEqual(expectedWordOccurrences, actualWordOccurrences);
        }

        [TestMethod]
        public void Count_ReturnsExpectedWordOccurrences_WhenDocumentContainsSpecialCharacters()
        {
            // Arrange
            var document = new Document("Hello, World! This is a test. It's a test? Yes, it is!");
            var expectedWordOccurrences = new Dictionary<string, int>
            {
                { "a", 2 },
                { "hello", 1 },
                { "is", 2 },
                { "it's", 1 },
                { "test", 2 },
                { "this", 1 },
                { "world", 1 },
                { "yes", 1 },
                { "it", 1 }
            };

            // Act
            var actualWordOccurrences = _wordsCounter.Count(document);

            // Assert
            actualWordOccurrences.Should().BeEquivalentTo(expectedWordOccurrences);

        }


    }
}

