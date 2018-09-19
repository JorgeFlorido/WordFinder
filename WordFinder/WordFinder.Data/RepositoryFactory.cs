namespace WordFinder.WordFinder.Data
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly string _dataSource;
        private readonly string _filePath;

        public RepositoryFactory(string dataSource, 
            string filePath)
        {
            _dataSource = dataSource;
            _filePath = filePath;
        }

        public IRepository Create()
        {
            switch (_dataSource)
            {
                case "local":
                    return new FileReader(_filePath);
                case "database":
                    return new DatabaseReader();
                default:
                    return new FileReader(_filePath);
            }
        }
    }
}
