using Dashboard.Data;
using Dashboard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MimeKit;
using MailKit.Net.Smtp;

namespace Dashboard.Controllers.Shopping
{
    public class ShoppingController : Controller
    {
        private readonly ApplicationDbContext context;

        public ShoppingController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var Product = context.Products.ToList();
            return View(Product);
        }

        //we added int id because we will use it depending on the item id
        public IActionResult ProductDetails(int id)
        {
            //where uses ienumrable
            //single or defulte uses list
            var ProductDetails = context.ProductDetails.Where(p => p.ProductId == id).ToList();
            return View(ProductDetails);
        }

        public async Task<string> SendMail()
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Test Email", "hiccupsder@gmail.com")); //sender

            message.To.Add(MailboxAddress.Parse("l676nal7arbi@gmail.com")); //reciver

            message.Subject = "Test Message From My Apps";

            message.Body = new TextPart("Test")
            { 
                Text = "<h1>This Test Message From My App</h1>"
            };

            using (var client  = new SmtpClient())
            {
                try
                {
                    //protocol
                    client.Connect("smtp.gmail.com", 587);
                    client.Authenticate("hiccupsder@gmail.com", "bezjlxbmhrsnmilu");
                    //will send the message
                    await client.SendAsync(message);
                    client.Disconnect(true);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message.ToString());
                    
                }
            };
            return "Ok";
        }

        //used to ask the user to authrize themselvs either by sign in or sign up
        [Authorize]
        public IActionResult CheckOut(int id)
        {
            var user = HttpContext.User.Identity.Name;
            var ProductDetails = context.ProductDetails.SingleOrDefault(p => p.ProductId == id);
            var cart = new Cart()
            {
                CustomersId = user,
                MyProductId = ProductDetails.ProductId,
                Color = ProductDetails.Color,
                Images = ProductDetails.Image,
                Price = ProductDetails.Price,
                Total = ProductDetails.Price * (15 / 100) + ProductDetails.Price,
                ProductName = ProductDetails.ProductName,
                Tax = 0.15
            };

            context.Cart.Add(cart);
            context.SaveChanges();
            return View(cart);
        }

        public IActionResult DashboardIndex() 
        {
            return RedirectToAction("Index", "Home");
        }

    }
}
