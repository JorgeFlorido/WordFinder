using System.Collections.Generic;

namespace WordFinder.WordFinder.Services
{
    public interface IWordLengthDiscriminator
    {
        IEnumerable<Word> GetValidWords(IEnumerable<Word> wordList);
        IEnumerable<Word> GetParts(IEnumerable<Word> wordList, IEnumerable<Word> validList);
    }
}