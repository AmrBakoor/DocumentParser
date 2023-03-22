using System;
namespace DocumentParser.BL.AbstractProducts
{
	public interface ISorter
	{
        Dictionary<string, int> Sort(Dictionary<string, int> dict);

    }
}

