using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using E_commerce_site.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;

namespace E_commerce_site.Pages
{
    public class AddToDBModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSender _emailSender;
        public readonly ILogger<AddToDBModel> _logger;
        public readonly AppDataContext _db;
        [BindProperty]
        public Product products { get; set; }

        public AddToDBModel(AppDataContext db, RoleManager<IdentityRole> roleManager, ILogger<AddToDBModel> logger, IEmailSender emailSender)
        {
            _db = db;
            _roleManager = roleManager;
            _emailSender = emailSender;
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                products.Price = products.Price * 1.20;
                _db.products.Add(products);
                _db.SaveChanges();
                return Page();
            }
            else
            {
                return RedirectToPage("Index");
            }
        }
    }
}
