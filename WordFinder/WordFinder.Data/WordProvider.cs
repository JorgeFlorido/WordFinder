using System;
using System.Collections.Generic;
using System.Linq;

namespace WordFinder.WordFinder.Data
{
    public class WordProvider : IDataProvider
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public WordProvider(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory ?? throw new ArgumentNullException(nameof(_repositoryFactory));
        }

        public IEnumerable<DataLine> GetDataLines()
        {
            return _repositoryFactory.Create()
                .GetData()
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Select(line => new DataLine { Value = line });
        }
    }
}
