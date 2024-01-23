using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Microsoft.EntityFrameworkCore;
using PetProjSite.Data;
using PetProjSite.Models;

namespace PetProjSite.Controllers
{
	public class CatalogController : Controller
	{
		private DataDbContext dtbs;

		public CatalogController(DataDbContext dtbs)
		{
			this.dtbs = dtbs;
		}
        public IActionResult Catalog()
		{
            IEnumerable<Models.Product> products = dtbs.Product.ToList();
            return View(products);
		}

		public IActionResult AddingNewProduct()
		{
			return View();
		}

		[HttpPost]
        public IActionResult AddingNewProduct(Models.Product product)
        {
            if (ModelState.IsValid)
            {
                if (LoginController.IsAdmin)
                {
                    bool productExist = dtbs.Product.Any(p => p.product_name == product.product_name);

                    if (!productExist)
                    {
                        dtbs.Product.Add(product);
                        dtbs.SaveChanges();
                    }
                    return RedirectToAction("Home", "Home");
                }
                
            }
            
            return RedirectToAction("Home", "Home");

        }

    }
}
