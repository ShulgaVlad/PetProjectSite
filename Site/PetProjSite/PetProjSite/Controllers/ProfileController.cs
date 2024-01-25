using Microsoft.AspNetCore.Mvc;
using PetProjSite.Data;

namespace PetProjSite.Controllers
{
    public class ProfileController : Controller
    {
        private DataDbContext dtbs;
        public ProfileController(DataDbContext dtbs)
        {
            this.dtbs = dtbs;
        }

        public IActionResult Profile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddingToHistory(int productId)
        {
            if(LoginController.LoggedUser != null)
            {
                Models.UserProfile userHisId = new Models.UserProfile();
                userHisId = dtbs.UserProfile.Find(LoginController.LoggedUser.id);

                Models.Product productHisId = new Models.Product();
                productHisId = dtbs.Product.Find(productId);
                bool hisExist = dtbs.Order.Any(p => p.Product.id == productId && p.UserProfile.id == LoginController.LoggedUser.id);
                if (hisExist)
                {
                    // Знайдіть існуючий об'єкт Order в базі даних
                    Models.Order productToHistory = dtbs.Order.FirstOrDefault(p => p.Product.id == productId && p.UserProfile.id == LoginController.LoggedUser.id);

                    // Перевірте, чи об'єкт існує
                    if (productToHistory != null)
                    {
                        // Видаліть об'єкт з бази даних
                        dtbs.Order.Remove(productToHistory);
                        dtbs.SaveChanges();
                    }
                }

                if (ModelState.IsValid)
                {
                    
                    Models.Order productToHistory = new Models.Order()
                    {
                        Product = productHisId,
                        UserProfile = userHisId,
                    };
                    dtbs.Order.Add(productToHistory);
                    dtbs.SaveChanges();
                }

                return RedirectToAction("Catalog", "Catalog");
            }
            return RedirectToAction("Home", "Home");
        }

    }
}
