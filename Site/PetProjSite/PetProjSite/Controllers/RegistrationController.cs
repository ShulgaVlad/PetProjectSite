using Microsoft.AspNetCore.Mvc;
using PetProjSite.Data;
using PetProjSite.Models;
using System.ComponentModel.DataAnnotations;

namespace PetProjSite.Controllers
{
    public class RegistrationController : Controller
    {
        private DataDbContext dtbs;

        public RegistrationController(DataDbContext dtbs)
        {
            this.dtbs = dtbs;
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(UserProfile user)
        {
            bool usExist = dtbs.UserProfile.Any(p => p.e_mail == user.e_mail);
            if (!usExist && new EmailAddressAttribute().IsValid(user.e_mail))
            {
                dtbs.UserProfile.Add(user);
                dtbs.SaveChanges();

                UserProfile newReader = dtbs.UserProfile.FirstOrDefault(p => p.e_mail == user.e_mail);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

    }
}
