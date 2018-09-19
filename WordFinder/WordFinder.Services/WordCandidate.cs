using System;

namespace WordFinder.WordFinder.Services
{
    public class WordCandidate
    {
        private readonly string _leftSide;
        private readonly string _rightSide;

        public WordCandidate(string leftSide, string rightSide)
        {
            _leftSide = leftSide ?? throw new ArgumentNullException(nameof(leftSide));
            _rightSide = rightSide ?? throw new ArgumentNullException(nameof(rightSide));
        }

        public string Value => _leftSide + _rightSide;
    }
}
