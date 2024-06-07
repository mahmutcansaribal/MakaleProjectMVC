using MakaleProject.Models.Context;
using MakaleProject.Models.RepositoryDesignPattern.EntityRepositories;

namespace MakaleProject.Models.RepositoryDesignPattern.RepositoryClasses
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private ArticleDbContext _articleDbContext;

        public UserRepository(ArticleDbContext articleDbContext):base(articleDbContext)
        {
            _articleDbContext = articleDbContext;
        }
    }
}

