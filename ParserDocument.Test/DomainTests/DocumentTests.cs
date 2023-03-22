using System;
using DocumentParser.Domain;
using DocumentParser.Domain.ConcreteProducts;
using FluentAssertions;

namespace ParserDocument.Test.DomainTests
{
    [TestClass]
    public class DocumentTests
    {

        [TestMethod]
        public void GetText_ReturnsText()
        {
            // Arrange
            string text = "This is a test document.";
            Document document = new Document(text);

            // Act
            string result = document.GetText();

            // Assert
            result.Should().BeEquivalentTo(text);
        }

        [TestMethod]
        public void GetNonNumericWords_ReturnsNonNumericWords()
        {
            // Arrange
            string text = "This is a test document with 123 numbers.";
            Document document = new Document(text);

            // Act
            string[] result = document.GetNonNumericWords();

            // Assert
            result.Should().BeEquivalentTo(new string[] { "This", "is", "a", "test", "document", "with", "numbers" });
        }

        [TestMethod]
        public void GetNonNumericWordsCount_ReturnsNonNumericWordsCount()
        {
            // Arrange
            string text = "This is a test document with 123 numbers.";
            Document document = new Document(text);

            // Act
            int result = document.GetNonNumericWordsCount();

            // Assert
            result.Should().Be(7);
        }
    }
}

