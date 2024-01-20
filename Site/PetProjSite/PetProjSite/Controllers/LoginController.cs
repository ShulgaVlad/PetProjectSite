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

        [HttpPost]
        public IActionResult Login(UserProfile RegisteredUser)
        {
            // Перевірка чи існує користувач із введеними ім'ям та паролем
            var user = dtbs.UserProfile.FirstOrDefault(v => v.e_mail == RegisteredUser.e_mail && v.password == RegisteredUser.password);

            if (user != null)
            {
                // Користувач знайдений, перенаправляємо його на головну сторінку
                IsAuthorisated = true;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Неправильне ім'я користувача або пароль");
                return View();
            }
        }

		[HttpPost]
		public IActionResult Logout()
		{
			IsAuthorisated = false;
			return RedirectToAction("Index", "Home");			
		}
	}
}
