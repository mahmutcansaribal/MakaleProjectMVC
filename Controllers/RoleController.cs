using MakaleProject.Models;
using MakaleProject.Models.Context;
using Microsoft.AspNetCore.Mvc;

namespace MakaleProject.Controllers
{
    public class RoleController : Controller
    {
        private readonly ArticleDbContext _articleDbContext;
        public RoleController(ArticleDbContext context)
        {
            _articleDbContext = context;
        }
        public IActionResult Index()
        {
            List<Role> roleList = _articleDbContext.Roles.ToList();
            return View(roleList);
        }
        public IActionResult Add(Role role)
        {
            if(ModelState.IsValid)
            {
                _articleDbContext.Roles.Add(role);
                _articleDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }
        public IActionResult Delete(int id)
        {
            Role role = _articleDbContext.Roles.Find(id);
            if(role != null)
            {
                _articleDbContext.Remove(role);
                _articleDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}
