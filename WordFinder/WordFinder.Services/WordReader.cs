using System;
using System.Collections.Generic;
using System.Linq;
using WordFinder.WordFinder.Data;

namespace WordFinder.WordFinder.Services
{
    public class WordReader : IWordReader
    {
        private readonly IDataProvider _wordProvider;

        public WordReader(IDataProvider wordProvider)
        {
            _wordProvider = wordProvider ?? throw new ArgumentNullException(nameof(wordProvider));
        }

        public IEnumerable<Word> GetWords()
        {
            return _wordProvider
                .GetDataLines()
                .Select(line => new Word {Value = line.Value});
        }
    }
}
