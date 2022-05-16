using bookstore.Data;
using bookstore.Data.Static;
using bookstore.Data.ViewModels;
using bookstore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Controllers
{
    public class AccountController : Controller
    {


        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManger;
        private readonly AppDbContext _context;


        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManger, AppDbContext context)
        {
            _userManager = userManager;
            _signInManger = signInManger;
            _context = context;



        }

        public async Task<IActionResult> Users()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }
        
        public IActionResult Login() => View(new LoginVM());
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAdress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    var result = await _signInManger.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Carti");
                    }
                }
                TempData["Error"] = "Date incorecte.Incearca din nou";
                return View(loginVM);

            }
            TempData["Error"] = "Date incorecte.Incearca din nou";
            return View(loginVM);
        }
        public IActionResult Register() => View(new RegisterVM());
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }
            var user = await _userManager.FindByEmailAsync(registerVM.EmailAdress);
            if (user != null)
            {
                TempData["Error"] = "Aceasta adresa de email este deja folosita";
                return View(registerVM);
            }
            var newUser = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAdress,
                UserName = registerVM.EmailAdress
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (!newUserResponse.Succeeded)
            {
                if (newUserResponse.Errors != null && newUserResponse.Errors.Count() > 0)
                {
                    var errorMessage = "";
                    foreach(var error in newUserResponse.Errors)
                    {
                           errorMessage += $"{error.Description}";
                    }
                    TempData["Error"] = errorMessage;
                }

                return View(registerVM);
            }

            await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            return View("RegisterCompleted");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManger.SignOutAsync();
            return RedirectToAction("Index", "Carti");
        }

        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }


    }
}
