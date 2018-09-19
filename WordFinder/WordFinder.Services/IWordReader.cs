using System.Collections.Generic;

namespace WordFinder.WordFinder.Services
{
    public interface IWordReader
    {
        IEnumerable<Word> GetWords();
    }
}