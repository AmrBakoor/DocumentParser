using System;
using DocumentParser.BL.AbstractProducts;
using DocumentParser.Domain;
using DocumentParser.Domain.AbstractProducts;

namespace DocumentParser.BL.ConcreteProducts
{
    public class WordsCounter : IWordsCounter
    {
        public Dictionary<string, int> Count(IDocument document)
        {
            var wordOccurrences = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (var word in document.GetNonNumericWords())
            {

                if (word.Length > 0)
                {
                    string wordLowerCase = word.ToLower();

                    if (wordOccurrences.ContainsKey(wordLowerCase))
                    {
                        wordOccurrences[wordLowerCase]++;
                    }
                    else
                    {
                        wordOccurrences[wordLowerCase] = 1;
                    }
                }
            }

            return wordOccurrences;
        }
    }
}

