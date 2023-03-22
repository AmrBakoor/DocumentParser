using System;
using System.Text.RegularExpressions;
using DocumentParser.Domain.AbstractProducts;
using static System.Net.Mime.MediaTypeNames;

namespace DocumentParser.Domain.ConcreteProducts
{
    /// <summary>
    ///  ConcereeDomian class to represent a document with text accorss all the app
    /// </summary>
    public class Document: IDocument
    {

        private readonly string text;

        public Document(string text)
        {
            this.text = text ?? string.Empty;
        }

        public string GetText()
        {
            return text;
        }

        public string[] GetNonNumericWords()
        {
            //var words = Regex.Matches(text, @"\b[^\d\W]+\b");
            var words = Regex.Matches(text, @"\b[\p{L}'-]+\b");
            return words.Cast<Match>().Select(match => match.Value).ToArray();
        }

        public int GetNonNumericWordsCount()
        {
            return GetNonNumericWords().Length;
        }
    }
}

