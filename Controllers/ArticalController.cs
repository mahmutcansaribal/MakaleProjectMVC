using MakaleProject.Models.Context;
using Microsoft.AspNetCore.Mvc;

namespace MakaleProject.Controllers
{
    public class ArticalController : Controller
    {
        private readonly ArticleDbContext _articleDbContext;
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserAddArticle(int id)
        {
            /* YAPILACAKLAR
              
            1- USER ID BULACAKSIN
            2- BURADA INTERFACE YAPISINI KULLANABİLİRSİN.
            3- BULDUKTAN SONRA O ID'YE ARTİCLE EKLEYECEKSİN.


             */
            var user = _articleDbContext.Users.Find(id);
            return View();
        }
    }
}
