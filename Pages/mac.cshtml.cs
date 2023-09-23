using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_commerce_site.Pages
{
    public class macModel : PageModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string description { get; set; }
        public string productImage { get; set; }
        public void OnGet()
        {
        }
    }
}
