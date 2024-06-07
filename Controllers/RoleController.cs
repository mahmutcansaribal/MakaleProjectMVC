using MakaleProject.Models;
using MakaleProject.Models.Context;
using MakaleProject.Models.RepositoryDesignPattern.EntityRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MakaleProject.Controllers
{
    public class RoleController : Controller
    {
        //private readonly ArticleDbContext _articleDbContext;
        private readonly IRoleRepository _roleRepository;
        public RoleController(IRoleRepository context)
        {
            _roleRepository = context;
        }
        public IActionResult Index()
        {
            //List<Role> roleList = _articleDbContext.Roles.ToList();
            List<Role> roleList = _roleRepository.GetAll().ToList();
            return View(roleList);
        }
        public IActionResult Add(Role role)
        {
            if(ModelState.IsValid)
            {
                //_articleDbContext.Roles.Add(role);
                //_articleDbContext.SaveChanges();
                _roleRepository.Add(role);
                _roleRepository.SaveDb();
                return RedirectToAction("Index");
            }
            return View(role);
        }
        public IActionResult Delete(int id)
        {
            Role role = _roleRepository.GetById(id);
            _roleRepository.DeleteById(role);
            _roleRepository.SaveDb();
            
            if(role == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            Role role = _roleRepository.GetById(id);
            if(role == null)
            {
                return NotFound();
            }
            return View(role);
        }
        [HttpPost]
        public IActionResult Update(Role role)
        {
            if (ModelState.IsValid)
            {
                _roleRepository.Update(role);
                _roleRepository.SaveDb();
                return RedirectToAction("Index");
            }
            return View();

        }

    }
}
