namespace MakaleProject.Models.RepositoryDesignPattern.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void DeleteById(T entity);
        void SaveDb();
    }
}
