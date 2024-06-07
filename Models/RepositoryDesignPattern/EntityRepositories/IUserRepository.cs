using MakaleProject.Models.RepositoryDesignPattern.IRepository;

namespace MakaleProject.Models.RepositoryDesignPattern.EntityRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        public List<User> GetUsers();
    }
}
