using MakaleProject.Models.Context;
using MakaleProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MakaleProject.Models.RepositoryDesignPattern.EntityRepositories;

namespace MakaleProject.Controllers
{
    public class UserController : Controller
    {
        private readonly ArticleDbContext _articleDbContext;
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository context, ArticleDbContext articleDbContext)
        {
            _userRepository = context;
            _articleDbContext = articleDbContext;
        }
        public IActionResult Index()
        {
            List<User> users = _userRepository.GetUsers();
            return View(users);
        }
        public string GetRoleName(int roleId)
        {
            var roleName = _articleDbContext.Roles.FirstOrDefault(r => r.RoleId == roleId)?.RoleName;
            return roleName ?? "";
        }
        [HttpGet]
        public IActionResult Add()
        {

            var roles = _articleDbContext.Roles.Select(r => new Role
            {
                RoleId = r.RoleId,
                RoleName = r.RoleName
            }).ToList();
            ViewBag.Roles = new SelectList(roles, "RoleId", "RoleName");
            return View();
        }
        [HttpPost]
        public IActionResult Add(User user)
        {
            if (!ModelState.IsValid)
            {

                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                Console.WriteLine("ModelState Hataları:");
                foreach (var state in ModelState)
                {
                    Console.WriteLine($"{state.Key}: {state.Value.Errors.FirstOrDefault()?.ErrorMessage}");
                }

                Console.WriteLine("User Nesnesi İçeriği:");
                Console.WriteLine($"ID: {user.ID}");
                Console.WriteLine($"Name: {user.Name}");
                Console.WriteLine($"MailAddress: {user.MailAddress}");
                Console.WriteLine($"Password: {user.Password}");
                Console.WriteLine($"State: {user.State}");
                Console.WriteLine($"RoleId: {user.RoleId}");
                return View(user);
            }

            _userRepository.Add(user);
            _userRepository.SaveDb();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            User user = _userRepository.GetById(id);
            if (user != null)
            {
                _userRepository.DeleteById(user);
                _userRepository.SaveDb();
                return RedirectToAction("Index");
            }
            return View();
        }
    }

}
