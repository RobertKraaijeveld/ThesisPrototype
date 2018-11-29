using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ThesisPrototype.Controllers;
using ThesisPrototype.ViewModels;

namespace ThesisPrototype
{
    public class AccountController : BaseController
    {
        public readonly SignInManager<User> _signInManager;

        public AccountController(SignInManager<User> signInManager,
                                 UserManager<User> userManager) : base(userManager)
        {
            _signInManager = signInManager;
        }


        public IActionResult Index()
        {
            return Login();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = "")
        {
            if(User.Identity.IsAuthenticated) return RedirectToAction("Index", "Dashboard");

            var model = new LoginViewModel { ReturnUrl = returnUrl };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await _signInManager.PasswordSignInAsync(model.Username, model.Password, 
                                                                           isPersistent: true, lockoutOnFailure: false);

                if (loginResult.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ModelState.AddModelError("", "Unknown username or password, please try again.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt");
            }
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }


        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid) // TODO: Handle invalid modelstate by returning errors
            {
                var user = new User { UserName = model.Username };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid registration attempt, please try again.");
            }

            return View();
        }
    }
}
