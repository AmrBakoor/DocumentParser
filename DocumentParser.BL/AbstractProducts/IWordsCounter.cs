using System;
using DocumentParser.Domain;
using DocumentParser.Domain.AbstractProducts;

namespace DocumentParser.BL.AbstractProducts
{
	public interface IWordsCounter
	{
        Dictionary<string, int> Count(IDocument document);
	}
}

