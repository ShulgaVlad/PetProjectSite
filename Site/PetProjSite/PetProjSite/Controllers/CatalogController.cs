using Microsoft.AspNetCore.Mvc;
using PetProjSite.Data;

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
            return View();
        }

        public IActionResult AddingNewProduct()
        {
            return View();
        }


    }
}
