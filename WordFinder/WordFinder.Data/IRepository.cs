using System.Collections.Generic;

namespace WordFinder.WordFinder.Data
{
    public interface IRepository
    {
        IEnumerable<string> GetData();
    }
}
