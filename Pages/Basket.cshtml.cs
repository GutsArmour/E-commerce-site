using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce_site.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace E_commerce_site.Pages
{
    public class BasketModel : PageModel
    {
        private readonly AppDataContext _db;
        [BindProperty(SupportsGet = true) ]
        public List<Product> basket { get; set; }
        [BindProperty(SupportsGet =true)]
        public int BasketId { get; set; }
        private readonly ILogger<BasketModel> _logger;
        public BasketModel(AppDataContext db, ILogger<BasketModel> logger)
        {
            _db = db;
            _logger = logger;
        }
        public void OnGet()
        {
            basket = _db.basket.ToList();
        }
        public IActionResult OnGetDelete()
        {
            _db.Remove(_db.basket.Find(BasketId));
            _db.SaveChanges();
            return RedirectToPage("/Basket");
        }
    }
}
