using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WishList.Models;
using WishList.Models.AccountViewModels;

namespace WishList.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager){
            this._signInManager=signInManager;
            this._userManager=userManager;
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Register(){
            return View("Register");
        }

        [HttpPost,AllowAnonymous]
        public IActionResult Register(RegisterViewModel model){
            
            if(!ModelState.IsValid){
                return View("Register",ModelState);
            }
            var newUser = new ApplicationUser();
            newUser.Email=model.Email;
            newUser.UserName=model.Email;
            newUser.PasswordHash=model.Password;
            var result = _userManager.CreateAsync(newUser);
            if(!result.Result.Succeeded){
                foreach(var error in result.Result.Errors){
                    ModelState.AddModelError("Password",error.Description);
                }
                return View("Register",model);
            }
            return RedirectToAction("Index","HomeController");
        }
    }
}