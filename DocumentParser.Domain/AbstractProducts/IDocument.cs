using System;
namespace DocumentParser.Domain.AbstractProducts
{
    /// <summary>
    /// Domain abstract contract
    /// </summary>
	public interface IDocument
	{
        string GetText();
        string[] GetNonNumericWords();
        int GetNonNumericWordsCount();
    }
}

