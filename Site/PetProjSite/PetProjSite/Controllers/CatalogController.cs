using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Microsoft.EntityFrameworkCore;
using PetProjSite.Data;
using PetProjSite.Models;
using System.Net;

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
        
        public IActionResult EditingProduct() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetProductId(int catalogId)
        {
            if (LoginController.IsAdmin)
            {
                int storedProductId = catalogId;
                TempData["CatalogId"] = storedProductId;
                return RedirectToAction("EditingProduct");
            }
            return RedirectToAction("Catalog");
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
                    return RedirectToAction("Catalog", "Catalog");
                }                
            }
            
            return RedirectToAction("Home", "Home");

        }

        [HttpPost]
        public IActionResult DeleteProduct(int catalogId)
        {
            var history = dtbs.Order.Where(p => p.Product.id == catalogId);
            dtbs.Order.RemoveRange(history);
            Models.Product deletedProduct = new Models.Product();
            deletedProduct = dtbs.Product.Find(catalogId);
            dtbs.Product.Remove(deletedProduct);
            dtbs.SaveChanges();
            return RedirectToAction("Catalog");
        }

        [HttpPost]
        public IActionResult EditingProduct(int id, string newProductName, int newProductPrice, string newProductDescription, string newProductPhoto, string newProductTotalCategory, string newProductSubCategory)
        {
            if (LoginController.IsAdmin)
            {
                if (ModelState.IsValid)
                {
                    Models.Product editedProduct = new Models.Product();
                    editedProduct = dtbs.Product.Find(id);
                    editedProduct.product_name = newProductName;
                    editedProduct.product_price = newProductPrice;
                    editedProduct.product_description = newProductDescription;
                    editedProduct.product_photo = newProductPhoto;
                    editedProduct.total_category = newProductTotalCategory;
                    editedProduct.sub_category = newProductSubCategory;
                    dtbs.Product.Update(editedProduct);
                    dtbs.SaveChanges();
                    return RedirectToAction("Catalog", "Catalog");
                }
                
            }
            return View();
        }

    }
}
