using MakaleProject.Models.Context;
using MakaleProject.Models.RepositoryDesignPattern.EntityRepositories;

namespace MakaleProject.Models.RepositoryDesignPattern.RepositoryClasses
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private ArticleDbContext _articleDbContext;

        public RoleRepository(ArticleDbContext articleDbContext) : base(articleDbContext)
        {
            _articleDbContext = articleDbContext;
        }

    }
}
