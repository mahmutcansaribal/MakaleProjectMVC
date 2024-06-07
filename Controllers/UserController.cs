using MakaleProject.Models.Context;
using MakaleProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MakaleProject.Controllers
{
    public class UserController : Controller
    {
        private readonly ArticleDbContext _articleDbContext;
        public UserController(ArticleDbContext context)
        {
            _articleDbContext = context;
        }
        public IActionResult Index()
        {
            List<User> users = _articleDbContext.Users.Include(u => u.Role).ToList();
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

            _articleDbContext.Users.Add(user);
            _articleDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            User user = _articleDbContext.Users.Find(id);
            if (user != null)
            {
                _articleDbContext.Remove(user);
                _articleDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }

}
