using Db_Chart_Proj.Data;
using System.Web.Mvc;

namespace Db_Chart_Proj.Controllers
{
    public class HomeController : Controller
    {
        private readonly SQLCommandRepository repo;
        public HomeController()
        {
            repo = new SQLCommandRepository();
        }
        public ActionResult Index()
        {
            var results = repo.GetAllCountries();
            return View(results);
        }

        public ActionResult About()
        {
           return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}