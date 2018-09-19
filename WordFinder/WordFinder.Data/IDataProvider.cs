using System.Collections.Generic;

namespace WordFinder.WordFinder.Data
{
    public interface IDataProvider
    {
        IEnumerable<DataLine> GetDataLines();
    }
}
