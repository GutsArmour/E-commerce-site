using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace E_commerce_site.Models
{
    public class Product
    {
        
        [Key]
        public int ProductId { get; set; }
        public int BasketId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ProductImage { get; set; }
        public int Quantity { get; set; }
    }
}
