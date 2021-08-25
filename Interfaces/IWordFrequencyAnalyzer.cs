using System;
using System.Collections.Generic;
using System.Text;

namespace WorldFrequency.Interfaces
{
    interface IWordFrequencyAnalyzer
    {
        int CalculateHighestFrequency(string text);
        int CalculateFrequencyForWord(string text, string word);
        IEnumerable<IWordFrequency> CalculateMostFrequentNWords(string text, int n);

    }
}
