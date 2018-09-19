using System.Collections.Generic;
using System.Linq;
using WordFinder.WordFinder.Services;

namespace WordFinder
{
    public class WordFinderFacade
    {
        private readonly IWordReader _reader;
        private readonly IWordLengthDiscriminator _discriminator;
        private readonly IWordMatchFinder _matchFinder;
        private readonly IWordCandidatesPicker _candidatesPicker;

        public WordFinderFacade(IWordCandidatesPicker candidatesPicker, 
            IWordMatchFinder matchFinder, 
            IWordLengthDiscriminator discriminator, 
            IWordReader reader)
        {
            _candidatesPicker = candidatesPicker;
            _matchFinder = matchFinder;
            _discriminator = discriminator;
            _reader = reader;
        }

        public IEnumerable<Word> GetWords()
        {
            var wordList = _reader.GetWords().ToList();

            var definedLengthWords = _discriminator.GetValidWords(wordList).ToList();
            var parts = _discriminator.GetParts(wordList, definedLengthWords).ToList();

            var candidates = _candidatesPicker.GetCandidates(parts);

            return _matchFinder.FindMatches(candidates, definedLengthWords);
        }
    }
}
