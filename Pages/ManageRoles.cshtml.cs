using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using E_commerce_site.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static E_commerce_site.Areas.Identity.Pages.Account.LoginModel;
using Microsoft.AspNetCore.Authorization;

namespace E_commerce_site.Pages
{

    public class ManageRolesModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        [BindProperty(SupportsGet = true)]
        public List<IdentityRole> Roles { get; set; }
        [BindProperty(SupportsGet = true)]

        public string Id { get; set; }
        [BindProperty(SupportsGet = true)]

        public string AdminString { get; set; }


        public ManageRolesModel(
            RoleManager<IdentityRole> roleManager,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Roles = await _roleManager.Roles.ToListAsync();

            return Page();
        }
        public async Task<IActionResult> OnGetDeleteAsync()
        {
            var role = await _roleManager.FindByIdAsync(Id);
            var result = await _roleManager.DeleteAsync(role);
            return RedirectToPage("/ManageUser");
        }
        /*public async Task<IActionResult> OnPostAsync()
        {
            var role = await _roleManager.FindByIdAsync(Id);
            await _roleManager.Remove(role.Name);
            await _roleManager.Add(role.Name, AdminString);
            return RedirectToPage("/ManageRole");
        }*/
    }
}
