using System;
using WordFinder.WordFinder.Services;

namespace WordFinder.Test.Helpers
{
    public static class Comparator
    {
        public static readonly Func<Word, Word, bool> WordComparer = (result, expected) => result.Value == expected.Value;

        public static readonly Func<WordCandidate, WordCandidate, bool> WordCandidateComparer = (result, expected) => result.Value == expected.Value;
    }
}
