using MakaleProject.Models.Context;
using MakaleProject.Models.RepositoryDesignPattern.EntityRepositories;
using Microsoft.EntityFrameworkCore;

namespace MakaleProject.Models.RepositoryDesignPattern.RepositoryClasses
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private ArticleDbContext _articleDbContext;

        public UserRepository(ArticleDbContext articleDbContext):base(articleDbContext)
        {
            _articleDbContext = articleDbContext;
        }

        public List<User> GetUsers()
        {
            List<User> users = _articleDbContext.Users.Include(u => u.Role).ToList();
            return users;
        }
    }
}

