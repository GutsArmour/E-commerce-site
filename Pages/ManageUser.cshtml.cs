using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using E_commerce_site.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static E_commerce_site.Areas.Identity.Pages.Account.LoginModel;

namespace E_commerce_site.Pages
{
    [Authorize(Roles = "Admin")]

    public class ManageUserModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        [BindProperty(SupportsGet = true)]
        public List<AppUser> Users { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        [BindProperty(SupportsGet = true)]
        public string PasswordString { get; set; }

        private readonly RoleManager<IdentityRole> _roleManager;
        [BindProperty(SupportsGet =true)]
        public List<IdentityRole> Roles { get; set; }
        

        public ManageUserModel(
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
            Users = await _userManager.Users.ToListAsync();
            Roles = await _roleManager.Roles.ToListAsync();

            return Page();
        }
        public async Task<IActionResult> OnGetDeleteAsync()
        {
            var user = await _userManager.FindByIdAsync(Id);
            var userResult = await _userManager.DeleteAsync(user);
            return RedirectToPage("/ManageUser");
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var users = await _userManager.FindByIdAsync(Id);
            await _userManager.RemovePasswordAsync(users);
            await _userManager.AddPasswordAsync(users, PasswordString);
            return RedirectToPage("/ManageUser");
        }
    }
}
