using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using E_commerce_site.Models;

namespace E_commerce_site.Pages
{
    public class EditProductModel : PageModel
    {
        public readonly AppDataContext _db;
        [BindProperty]
        public Product products { get; set; }
        [BindProperty (SupportsGet =true)]
        public int Id { get; set; }
       
        public EditProductModel(AppDataContext db)
        {
            _db = db;
        }        
        public void OnGet()
        {
            products = _db.products.Find(Id);
        }
        public IActionResult OnPost()
        {
            _db.products.Update(products);
            _db.SaveChanges();
            return Page();
        }
    }
}
