using Dashboard.Data;
using Dashboard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Dashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext context;

        public HomeController(ApplicationDbContext context)
        {
            this.context = context;
        }
		
		//used to show the login page in the website
		[Authorize]
		public IActionResult Index()
		{
			var Name = HttpContext.User.Identity.Name;
			//method 1 of state management
			CookieOptions options = new CookieOptions();
			options.Expires = DateTime.Now.AddMinutes(10);
			Response.Cookies.Append("Name", Name, options);
			//method 2 of state management
			//HttpContext.Session.SetString("Name", Name);

			//method 3 of state management
			//TempData["Name"] = Name;
			ViewBag.Name = Name;
			var product = context.Products.ToList();
			return View(product);
		}

		//used only to show the page
		public IActionResult PaymentAccept()
		{
			return View();
		}

		//used for the actual work such validation
		[HttpPost]
        public IActionResult PaymentAccept(PaymentAccept paymentaccept)
        {
			if (ModelState.IsValid)
			{
				return RedirectToAction("Index");
			}
            return View();
        }


        public IActionResult AddProduct(Product product)
        {
			context.Products.Add(product);
			context.SaveChanges();
			return RedirectToAction("Index");
        }

		//
		[HttpPost]
		public IActionResult AddProductDetails(ProductDetails productDetails)
		{
			context.ProductDetails.Add(productDetails);
			context.SaveChanges();
			return RedirectToAction("ProductDetails");
		}

		//CONTINUE
		[HttpPost]
		public IActionResult ProductDetails(int id)
		{
			var ProductDetails = context.ProductDetails.Where(p => p.ProductId == id).ToList();	
			var product = context.Products.ToList();
			ViewBag.ProductDetails = ProductDetails;
			return View(product);
		}

		//CONTINUE
		public IActionResult ProductDetails()
		{
			var product = context.Products.ToList();
			var ProductDetails = context.ProductDetails.ToList();
			ViewBag.ProductDetails = ProductDetails;
			//method 1 of state management
			ViewBag.Name = Request.Cookies["Name"];
			//method2 of state management
			//ViewBag.Name = HttpContext.Session.GetString("Name");

			//method 3 of state management
			//ViewBag.Name = TempData["Name"];
			return View(product);
		}


		public IActionResult Edit(int id)
        {
            var product = context.Products.SingleOrDefault(p => p.Id == id);

            return View(product);
        }

		public IActionResult UpdateProducts(Product product)
		{
			//method 1 a bit hard
			var productUpdate = context.Products.SingleOrDefault(p => p.Id == product.Id)?? new Product();
			 if(productUpdate != null)
			{
			productUpdate.ProductName = product.ProductName;
			context.SaveChanges();
			}

			//method 2 eazy
			//context.Products.Update(product);
			//context.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Delete(int id)
		{
			var product = context.Products.SingleOrDefault(p => p.Id == id);
			if (product != null)
			{
				context.Products.Remove(product);
				context.SaveChanges();
			}
			return RedirectToAction("Index");
		}

        public IActionResult DeleteDetails(int id)
        {
            var product = context.ProductDetails.SingleOrDefault(p => p.Id == id);
            if (product != null)
            {
                context.ProductDetails.Remove(product);
                context.SaveChanges();
            }
            return RedirectToAction("ProductDetails");
        }

		[HttpPost]
		public IActionResult Index(string ProductName)
		{
			//where and tolist used because we are searching among a group not just  single product
			//contains used so if a letter is missing it stll can search and show a result
			var products = context.Products.Where(x => x.ProductName.Contains(ProductName)).ToList();

			return View(products);

		}



		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}