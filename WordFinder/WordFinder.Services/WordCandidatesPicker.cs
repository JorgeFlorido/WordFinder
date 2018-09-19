using System.Collections.Generic;

namespace WordFinder.WordFinder.Services
{
    public class WordCandidatesPicker : IWordCandidatesPicker
    {
        private readonly int _length;

        public WordCandidatesPicker(int length)
        {
            _length = length;
        }

        public IEnumerable<WordCandidate> GetCandidates(IReadOnlyList<Word> words)
        {
            var validWordList = new List<WordCandidate>();

            for (var i = 0; i < words.Count - 1; i++)
            {
                for (var j = i; j < words.Count - 1; j ++)
                {
                    if (words[i].Value.Length + words[j].Value.Length == _length)
                    {
                        validWordList.Add(new WordCandidate(words[i].Value, words[j].Value));

                        if (words[i].Value != words[j].Value)
                            validWordList.Add(new WordCandidate(words[j].Value, words[i].Value));
                    }
                }
            }

            return validWordList;
        }
    }
}
