using PetProjSite.Data;
using PetProjSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PetProjSite.Controllers
{
    public class LoginController : Controller
    {
        private DataDbContext dtbs;

        public static bool IsAdmin = false;
        public static bool IsAuthorisated = false;

        public LoginController(DataDbContext dtbs)
        {
            this.dtbs = dtbs;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult AdminLogin()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
