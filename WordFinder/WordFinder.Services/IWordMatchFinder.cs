using System.Collections.Generic;

namespace WordFinder.WordFinder.Services
{
    public interface IWordMatchFinder
    {
        IEnumerable<Word> FindMatches(IEnumerable<WordCandidate> candidates, 
            IEnumerable<Word> words);
    }
}