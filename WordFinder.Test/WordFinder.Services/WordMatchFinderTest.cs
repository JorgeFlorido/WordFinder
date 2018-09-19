using System.Collections.Generic;
using NUnit.Framework;
using WordFinder.Test.Helpers;
using WordFinder.WordFinder.Services;

namespace WordFinder.Test.WordFinder.Services
{
    [TestFixture]
    public class WordMatchFinderTest
    {
        private IEnumerable<Word> _wordList;
        private IEnumerable<Word> _expected;
        private IEnumerable<WordCandidate> _nonExisting;
        private IEnumerable<WordCandidate> _candidates;
        private IWordMatchFinder _matchFinder;

        [SetUp]
        public void Setup()
        {
            _wordList = GetWordListFake();
            _expected = ExpectedResult();
            _nonExisting = GetInvalidCandidatesFake();
            _candidates = GetValidCandidatesFake();
            _matchFinder = new WordMatchFinder();
        }

        [Test]
        public void GivenValidData_ShouldFindMatches()
        {
            var result = _matchFinder.FindMatches(_candidates, _wordList);

            Assert.That(result, Is.EquivalentTo(_expected).Using(Comparator.WordComparer));
        }

        [Test]
        public void GivenInvalidData_ShouldReturnEmptyList()
        {
            var result = _matchFinder.FindMatches(_nonExisting, _wordList);

            Assert.That(result, Is.Empty);
        }

        private static IEnumerable<Word> GetWordListFake()
        {
            return new List<Word>()
            {
                new Word() {Value = "House"},
                new Word() {Value = "ZigZag"},
                new Word() {Value = "Batman"},
                new Word() {Value = "Two"},
                new Word() {Value = "Absurd"},
                new Word() {Value = "Impossible"},
                new Word() {Value = "Twelve"},
                new Word() {Value = "I"},
                new Word() {Value = "Orange"},
                new Word() {Value = "TheLongestWordInTheWorldYouCanEvenImagineNoMatterHowMuchTimeYouSpendOnIt"}
            };
        }

        private static IEnumerable<WordCandidate> GetValidCandidatesFake()
        {
            return new List<WordCandidate>()
            {
                new WordCandidate("Hou", "se"),
                new WordCandidate("Bat", "man"),
                new WordCandidate("Tw", "o"),
                new WordCandidate("Impos", "sible")
            };
        }

        private static IEnumerable<WordCandidate> GetInvalidCandidatesFake()
        {
            return new List<WordCandidate>()
            {
                new WordCandidate("Piz", "za"),
                new WordCandidate("Tab", "le"),
                new WordCandidate("Sk", "ate"),
                new WordCandidate("Ug", "ly")
            };
        }

        private static IEnumerable<Word> ExpectedResult()
        {
            return new List<Word>()
            {
                new Word() {Value = "House"},
                new Word() {Value = "Batman"},
                new Word() {Value = "Two"},
                new Word() {Value = "Impossible"}
            };
        }
    }
}
