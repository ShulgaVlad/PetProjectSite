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

        public ActionResult EditingProduct()
        {
            return View();
        }

        public ActionResult GetProductId(int catalogId)
        {
            int storedCatalogId = catalogId;
            TempData["CatalogId"] = storedCatalogId;
            return RedirectToAction("EditingProduct");
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
        [HttpPost]
        public ActionResult EditingProduct(int id, string newProductName, int newProductPrice, string newProductDescriprion, string newProductPhoto, string newProductTotalCategory, string newProductSubCategory)
        {
            if (LoginController.IsAdmin)
            {                
                if (ModelState.IsValid)
                {
                    Console.WriteLine(newProductPhoto, newProductName, newProductPrice, newProductDescriprion, newProductTotalCategory, id);
                    Models.Product editedProduct = new Models.Product();
                    editedProduct = dtbs.Product.Find(id);
                    editedProduct.product_name = newProductName;
                    editedProduct.product_price = newProductPrice;
                    editedProduct.product_description = newProductDescriprion;
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

        [HttpPost]
        public ActionResult DeleteProduct(int catalogId)
        {
            Models.Product deletedProduct = new Models.Product();
            deletedProduct = dtbs.Product.Find(catalogId);
            dtbs.Product.Remove(deletedProduct);
            dtbs.SaveChanges();
            return RedirectToAction("Catalog", "Catalog");
        }

    }
}
