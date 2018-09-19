using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using WordFinder.Test.Helpers;
using WordFinder.WordFinder.Services;

namespace WordFinder.Test.WordFinder.Services
{
    [TestFixture]
    public class WordLengthDiscriminatorTest
    {
        private IWordLengthDiscriminator _discriminator;
        private IEnumerable<Word> _wordList;
        private IEnumerable<Word> _validList;

        [SetUp]
        public void Setup()
        {
            _discriminator = new WordLengthDiscriminator(6);
            _wordList = GetWordListFake();
            _validList = GetSixLettersWordListFake();
        }        

        [Test]
        public void ShouldReturnWordsWithSpecifiedLength()
        {
            var result = _discriminator.GetValidWords(_wordList);

            Assert.That(result.ToList(), Is.EquivalentTo(_validList).Using(Comparator.WordComparer));
        }

        [Test]
        public void ShouldReturnWordsWithLessThanSpecifiedLength()
        {
            var expected = GetLessThanSixLettersWordListFake();

            var result = _discriminator.GetParts(_wordList, _validList);

            Assert.That(result.ToList(), Is.EquivalentTo(expected).Using(Comparator.WordComparer));
        }

        [Test]
        public void GivenZeroLength_WordsShouldReturnEmptyList()
        {
            var discriminator = new WordLengthDiscriminator(0);

            var result = discriminator.GetValidWords(_wordList);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void GivenOneLength_PartsShouldReturnEmptyList()
        {
            var discriminator = new WordLengthDiscriminator(1);

            var result = discriminator.GetParts(_wordList, _validList);

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

        private static IEnumerable<Word> GetSixLettersWordListFake()
        {
            return new List<Word>()
            {
                new Word() {Value = "ZigZag"},
                new Word() {Value = "Batman"},
                new Word() {Value = "Absurd"},
                new Word() {Value = "Twelve"},
                new Word() {Value = "Orange"}
            };
        }

        private static IEnumerable<Word> GetLessThanSixLettersWordListFake()
        {
            return new List<Word>()
            {
                new Word() {Value = "House"},
                new Word() {Value = "Two"},
                new Word() {Value = "I"}
            };
        }
    }
}