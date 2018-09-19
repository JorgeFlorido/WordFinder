namespace WordFinder.WordFinder.Data
{
    public interface IRepositoryFactory
    {
        IRepository Create();
    }
}