using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using E_commerce_site.Models;

namespace E_commerce_site.Pages
{
    public class acerModel : PageModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ProductImage { get; set; }
        public void OnGet()
        {
            Id = 01;
            Name = "Acer Swift 3";
            Description = "The Acer Swift is perfect for a lot of people, it's exremely affordable for a laptop that gets day to day tasks done like document development and web research without any flaws. It can perform these tasks with excellent multi-tasking so that you can get your work done efficiently with no time to waste. In addition, it is built with really high quality hardware choices and upgrades so on top of its sturdiness, it is also has better performance including a very versatile battery life.";
            Price = 599;
            ProductImage = "assets/acer img.jpg";
        }
    }
}
