using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using WordFinder.Test.Helpers;
using WordFinder.WordFinder.Data;
using WordFinder.WordFinder.Services;

namespace WordFinder.Test.WordFinder.Services
{
    [TestFixture]
    public class WordReaderTest
    {
        private Mock<IDataProvider> _wordProvider;
        private IWordReader _reader;

        [SetUp]
        public void Setup()
        {
            _wordProvider = new Mock<IDataProvider>();
            _wordProvider.Setup(prov => prov.GetDataLines()).Returns(DataLineListFake());

            _reader = new WordReader(_wordProvider.Object);
        }

        [Test]
        public void ShouldReturnWordList()
        {
            var result = _reader.GetWords();
            var expected = ExpectedWords();

            Assert.That(result, Is.EquivalentTo(expected).Using(Comparator.WordComparer));
        }

        private static IEnumerable<DataLine> DataLineListFake()
        {
            return new List<DataLine>()
            {
                new DataLine() {Value = "Record"},
                new DataLine() {Value = "Mouse"},
                new DataLine() {Value = "Puzzle"},
                new DataLine() {Value = "Two"},
                new DataLine() {Value = "One"}
            };
        }

        private static IEnumerable<Word> ExpectedWords()
        {
            return new List<Word>()
            {
                new Word() {Value = "Record"},
                new Word() {Value = "Mouse"},
                new Word() {Value = "Puzzle"},
                new Word() {Value = "Two"},
                new Word() {Value = "One"}
            };
        }
    }
}