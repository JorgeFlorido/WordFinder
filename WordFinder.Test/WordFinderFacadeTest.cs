using Moq;
using NUnit.Framework;
using WordFinder.WordFinder.Data;
using WordFinder.WordFinder.Services;

namespace WordFinder.Test
{
    [TestFixture]
    public class WordFinderFacadeTest
    {
        private Mock<IWordReader> _reader;
        private Mock<IWordLengthDiscriminator> _discriminator;
        private Mock<IWordMatchFinder> _matchFinder;
        private Mock<IWordCandidatesPicker> _candidatesPicker;
        private Mock<IDataProvider> _dataProvider;
        private Mock<IRepositoryFactory> _repositoryFactory;

        [SetUp]
        public void Setup()
        {
            _repositoryFactory = new Mock<IRepositoryFactory>("local", "file.txt");
            _dataProvider = new Mock<IDataProvider>(_repositoryFactory.Object);
            _reader = new Mock<IWordReader>(_dataProvider.Object);
            _discriminator = new Mock<IWordLengthDiscriminator>(6);
            _candidatesPicker = new Mock<IWordCandidatesPicker>(6);
            _matchFinder = new Mock<IWordMatchFinder>();
        }

        [Test]
        public void ShouldIdentifyWords()
        {

        }
    }
}
