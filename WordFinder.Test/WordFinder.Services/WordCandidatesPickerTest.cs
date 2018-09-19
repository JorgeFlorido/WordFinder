using System.Collections.Generic;
using NUnit.Framework;
using WordFinder.Test.Helpers;
using WordFinder.WordFinder.Services;

namespace WordFinder.Test.WordFinder.Services
{
    [TestFixture]
    public class WordCandidatesPickerTest
    {
        private IWordCandidatesPicker _candidatesPicker;

        [SetUp]
        public void Setup()
        {
            _candidatesPicker = new WordCandidatesPicker(6);
        }

        [Test]
        public void ShouldReturnCandidates()
        {
            var expected = GetCandidatesListFake();
            var words = GetWordListFake();
            var result = _candidatesPicker.GetCandidates(words);

            Assert.That(result, Is.EquivalentTo(expected).Using(Comparator.WordCandidateComparer));
        }

        private static IReadOnlyList<Word> GetWordListFake()
        {
            return new List<Word>()
            {
                new Word() {Value = "Zig"},
                new Word() {Value = "Zag"},
                new Word() {Value = "Three"},
                new Word() {Value = "Absurd"},
                new Word() {Value = "Impossible"},
                new Word() {Value = "Zug"},
                new Word() {Value = "Orange"},
                new Word() {Value = "TheLongestWordInTheWorldYouCanEvenImagineNoMatterHowMuchTimeYouSpendOnIt"}
            };
        }

        private static IEnumerable<WordCandidate> GetCandidatesListFake()
        {
            return new List<WordCandidate>()
            {
                new WordCandidate("Zig", "Zig"), 
                new WordCandidate("Zag", "Zag"), 
                new WordCandidate("Zug", "Zug"), 
                new WordCandidate("Zig", "Zag"), 
                new WordCandidate("Zag", "Zig"), 
                new WordCandidate("Zig", "Zug"), 
                new WordCandidate("Zug", "Zig"), 
                new WordCandidate("Zag", "Zug"), 
                new WordCandidate("Zug", "Zag") 
            };
        }
    }
}
