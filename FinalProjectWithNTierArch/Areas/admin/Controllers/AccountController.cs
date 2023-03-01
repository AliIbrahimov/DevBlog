using AutoMapper;
using Entity.Concrete;
using Entity.ViewModels.AppUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithNTierArch.Areas.admin.Controllers;
[Area("admin")]
public class AccountController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IMapper _mapper;

    public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager, IMapper mapper)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
        _mapper = mapper;
    }

    /* public async Task<IActionResult> Index()
     {
         AppUser user = new AppUser() { Email = "admin@gmail.com", UserName = "admin" };
         await _userManager.CreateAsync(user, "Admin123@");
         await _userManager.AddToRoleAsync(user, "Admin");
         return Json("Ok");
     }*/
    public async Task<IActionResult> Login()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginVM loginVM)
    {
        var existUser = await _userManager.FindByEmailAsync(loginVM.Mail);
        if (existUser is null)
        {
            ModelState.AddModelError("", "User is not found!");
            return View(loginVM);
        }
        var result = await _signInManager.PasswordSignInAsync(existUser, loginVM.Password, true, true);
        if (!result.Succeeded)
        {
            ModelState.AddModelError("", "Username or password incorrect!");
            return View(loginVM);
        }
        return RedirectToAction("Index", "Dashboard");
    }
}
