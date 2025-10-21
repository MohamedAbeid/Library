using Library.Models;
using Library.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Users> userManager;
        private readonly SignInManager<Users> signInManger;

        public AccountController(UserManager<Users> userManager, SignInManager<Users> signInManger)
        { 
            this.userManager = userManager;
            this.signInManger = signInManger;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel newUserVM)
        {
            if (ModelState.IsValid)
            {
                Users userModel = new Users();
                userModel.UserName = newUserVM.Name;
                userModel.Email = newUserVM.Email;
                userModel.PasswordHash = newUserVM.Password;
                IdentityResult result =  await userManager.CreateAsync(userModel, newUserVM.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(userModel, "User");
                    await signInManger.SignInAsync(userModel,false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors
)
                    {
                        ModelState.AddModelError("Password", item.Description);
                        
                    }
                }
            }
            return View(newUserVM);
        }

        public IActionResult Logout()
        {
            signInManger.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                Users userModel = await userManager.FindByEmailAsync(userViewModel.Email);
                if (userModel != null)
                {
                    bool found = await userManager.CheckPasswordAsync(userModel, userViewModel.Password);
                    if (found)
                    {
                        await signInManger.SignInAsync(userModel, userViewModel.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("","Email Or Password Wrong");
            }
            return View(userViewModel);
        }
    }
}
