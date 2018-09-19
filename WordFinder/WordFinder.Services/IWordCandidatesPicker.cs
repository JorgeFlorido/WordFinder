using System.Collections.Generic;

namespace WordFinder.WordFinder.Services
{
    public interface IWordCandidatesPicker
    {
        IEnumerable<WordCandidate> GetCandidates(IReadOnlyList<Word> words);
    }
}