using System;
using System.Configuration;
using System.IO;
using WordFinder.WordFinder.Data;
using WordFinder.WordFinder.Services;

namespace WordFinder
{
    public static class AppInit
    {
        private static readonly string DataSource = ConfigurationManager.AppSettings.Get("DataSource");
        private static readonly string FilePath = $"{Environment.CurrentDirectory}\\wordlist.txt";
        private static readonly string WordLength = ConfigurationManager.AppSettings.Get("WordLength");

        public static WordFinderFacade Run()
        {
            var wordSize = Validate();
            return CreateInstances(wordSize);
        }

        private static int Validate()
        {
            if (string.IsNullOrEmpty(DataSource))
                throw new ConfigurationErrorsException(nameof(DataSource));            
            if (string.IsNullOrEmpty(FilePath))
                throw new ConfigurationErrorsException(nameof(FilePath));
            if (string.IsNullOrEmpty(WordLength))
                throw new ConfigurationErrorsException(nameof(WordLength));

            if (!File.Exists(FilePath))
                throw new FileNotFoundException(nameof(FilePath));
            if (!int.TryParse(WordLength, out var length))
                throw new ArgumentOutOfRangeException(nameof(WordLength));

            return length;
        }

        private static WordFinderFacade CreateInstances(int wordSize)
        {
            var repositoryFactory = new RepositoryFactory(DataSource, FilePath);
            var wordProvider = new WordProvider(repositoryFactory);

            var reader = new WordReader(wordProvider);
            var matchFinder = new WordMatchFinder();
            var discriminator = new WordLengthDiscriminator(wordSize);
            var candidatesPicker = new WordCandidatesPicker(wordSize);

            return new WordFinderFacade(candidatesPicker, matchFinder, discriminator, reader);
        }
    }
}