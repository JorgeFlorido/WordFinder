using NUnit.Framework;
using Moq;
using WordFinder.WordFinder.Data;
using System;
using System.Collections.Generic;

namespace WordFinder.Test.WordFinder.Data
{
    [TestFixture]
    public class WordProviderTest
    {
        private Mock<IRepositoryFactory> _repoMock;
        private IDataProvider _wordProvider;

        [SetUp]
        public void Setup()
        {
            _repoMock = new Mock<IRepositoryFactory>();
            _wordProvider = new WordProvider(_repoMock.Object);
        }

        [Test]
        public void ShouldThrowExceptionWhenNullRepo()
        {
            Assert.Throws<ArgumentNullException>(() => new WordProvider(null));
        }

        [Test]
        public void ShouldReturnWordList()
        {
            var words = new[] {
                "This",
                "is",
                "a",
                "test"
            };

            var expected = GetMockedWordList();

            _repoMock.Setup(rep => rep.Create().GetData()).Returns(words);

            var result = _wordProvider.GetDataLines();

            Assert.That(result, Is.EquivalentTo(expected).Using(WordComparer));
        }

        [Test]
        public void ShouldReturnWordListWithoutLineBreaks()
        {
            var words = new[] {
                null,
                "This",
                "is",
                " ",
                string.Empty,
                "a",
                "",
                null,
                "test",
                "   "
            };

            var expected = GetMockedWordList();

            _repoMock.Setup(rep => rep.Create().GetData()).Returns(words);

            var result = _wordProvider.GetDataLines();

            Assert.That(result, Is.EquivalentTo(expected).Using(WordComparer));
        }

        private static IEnumerable<DataLine> GetMockedWordList()
        {
          return new List<DataLine> {
            new DataLine { Value = "This" },
            new DataLine { Value = "is" },
            new DataLine { Value = "a" },
            new DataLine { Value = "test" },
          };
        }

        private static readonly Func<DataLine, DataLine, bool> WordComparer = (result, expected) => result.Value == expected.Value;
    }
}
