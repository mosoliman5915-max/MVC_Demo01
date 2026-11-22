using Microsoft.AspNetCore.Mvc;
using Gym_System.Models;
namespace Gym_System.Controllers
{
    [Route("Test")]
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        #region Get Products
        [HttpGet]
        public JsonResult GetProducts()
        {
            var Products = new List<Product>()
            {
                new Product { Id = 10, Name = "Protein Powder" },
                new Product { Id = 11, Name = "Dumbbells" },
                new Product { Id = 12, Name = "Yoga Mat" },
                new Product { Id = 13, Name = "Resistance Bands" },
                new Product { Id = 14, Name = "Treadmill" }

            };
            return Json(Products);

        }


        #endregion

        #region Get ProductById

        [HttpGet]

        public IActionResult GetProductById( int id)

        {
            if (id < 0)
                return BadRequest();
            else if (id == 0)
                return RedirectToAction(nameof(Index));
            else if (id < 10 || id > 14)
                return NotFound();
            else 
                return Json (new Product { Id = id , Name = "Creatine" }); 
             

        }



        #endregion

        #region Action

        public IActionResult FileAction()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes("C:\\Users\\DAR\\source\\repos\\Gym_System\\Gym_System\\wwwroot\\files\\sample.pdf");
  
            return File(fileBytes, "application/pdf", "sample.pdf");
 
        }

#endregion
        #region Routing
        [Route("Test")]

        [HttpGet("json")]

        public IActionResult JsonAction()
        {
            return Json("Hello from JsonAction");

        }

        [HttpGet("ProductCode/{Code:int}")]

        public IActionResult ProductCode(int code)
        {
            return Json(new Product { Id = code, Name = $"Product01" });
        }

        #endregion


        #region Model binding

        [HttpGet]
        public IActionResult Search(ProductsFilter filter)

        {
            return View();

        }

        [HttpGet]
        public IActionResult  ([FromQuery] int id, [FromQuery(Name ="id2")] int otherId)
        {
            return Json(new { source = "Query", id, otherId });
        }
        #endregion


    }
}
