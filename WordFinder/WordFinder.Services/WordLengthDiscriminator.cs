using System.Collections.Generic;
using System.Linq;

namespace WordFinder.WordFinder.Services
{
    public class WordLengthDiscriminator : IWordLengthDiscriminator
    {
        private readonly int _length;

        public WordLengthDiscriminator(int length)
        {
            _length = length;
        }

        public IEnumerable<Word> GetValidWords(IEnumerable<Word> wordList)
        {
            return wordList.Where(word => word.Value.Length == _length);
        }

        public IEnumerable<Word> GetParts(IEnumerable<Word> wordList, IEnumerable<Word> validList)
        {
            return wordList.Except(validList)
                .Where(word => word.Value.Length < _length);
        }
    }
}
