using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce_site.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_site.Pages
{
    public class IndexModel : PageModel
    {
        public readonly AppDataContext _db;
        [BindProperty(SupportsGet =true)]
        public List<Product> products { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }
        [BindProperty(SupportsGet =true)]
        public int Id { get; set; }
        [BindProperty (SupportsGet =true)]
        public List<Product> basket { get; set; }
        private readonly ILogger<IndexModel>_logger;

        Random rnd = new Random();
        
        public IndexModel(AppDataContext db, ILogger<IndexModel> logger)
        {
            _db = db;
            _logger = logger;
        }
        /*    public void OnGet()
                {

                    products = new List<Product> { 
                    new Product()
                    {
                        Name = "Acer Swift 3",
                        Description = "The Acer Swift is a really good choice for you if you need a laptop that is extremely easy to carry around anwhere you go. It's thin and light quality build means it is very portable but also very sturdy. It won't break even if you try!",
                        Price = 599,
                        ProductImage = "assets/acer slim.jpg"
                    },
                    new Product()
                    {
                        Name = "MacBook Air M1",
                        Description = "The all new MacBook Air allows you to multitask with smoothness but with a huge improvement to battery life with the new Mac OS Big Sur. As the newest OS Apple has created, it tops all the old MacBook by miles and its beautiful, luxury design is packed with enhancements.",
                        Price = 899,
                        ProductImage = "assets/mac os.jpg"
                    },
                    new Product()
                    {
                        Name = "Microsoft Surface Pro 7",
                        Description = "The Surface Pro 7 is a highly recommended laptop for its variety of usability. It can be turned into a touch screen tablet by removing the Type cover and can turn back into a laptop by simply reattaching the Type cover for writing up your long essays.",
                        Price = 769,
                        ProductImage = "assets/surface pro portable.jpg"
                    },
                    };
                }*/
        public async Task OnGetAsync()
        {
            products = _db.products.ToList();

            var laptops = from m in _db.products
                         select m;
            if (!string.IsNullOrEmpty(Search))
            {
                laptops = laptops.Where(s => s.Name.Contains(Search));
            }

            products = await laptops.ToListAsync();
        }

        public IActionResult OnGetDelete()
        {
            _db.Remove(_db.products.Find(Id));
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
        public IActionResult OnPost()
        {
            var product = _db.products.Find(Id);
            var cart = new Product()
            {
                BasketId = rnd.Next(),
                Name = product.Name,
                Price = product.Price,
                ProductImage = product.ProductImage,
                Quantity = product.Quantity
            };
            _db.basket.Add(cart);
            _db.SaveChanges();
            return RedirectToPage("/Index");
        }
    }
}