using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce_site.Models
{
    public class AppDataContext : IdentityDbContext <AppUser>
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        { }
        public DbSet<Product> products { get; set; }
        public DbSet<Product> basket { get; set; }

    }
}
