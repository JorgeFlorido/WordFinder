using System.Collections.Generic;
using System.IO;

namespace WordFinder.WordFinder.Data
{
    public class FileReader : IRepository
    {
        private readonly string _dataSource;

        public FileReader(string dataSource)
        {
            _dataSource = dataSource;
        }

        public IEnumerable<string> GetData()
        {
            return GetAllLines(_dataSource);
        }

        private IEnumerable<string> GetAllLines(string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException(nameof(path));
            return File.ReadAllLines(path);
        }
    }
}
