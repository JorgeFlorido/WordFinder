using System.Collections.Generic;
using System.Linq;

namespace WordFinder.WordFinder.Services
{
    public class WordMatchFinder : IWordMatchFinder
    {
        public IEnumerable<Word> FindMatches(IEnumerable<WordCandidate> candidates, 
            IEnumerable<Word> words)
        {
            return (from candidate in candidates
                from word in words
                where candidate.Value == word.Value
                select new Word {Value = candidate.Value});
        }
    }
}
