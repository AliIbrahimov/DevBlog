using AutoMapper;
using Entity.Concrete;
using Entity.ViewModels.AppUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using NuGet.Protocol.Plugins;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Business.Abstract;
using Entity.ViewModels.Developer;
using System.Xml.Linq;
using Core.Utilities.Extensions;
using Entity.ViewModels.Project;

namespace FinalProjectWithNTierArch.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IDeveloperService _developer;
    private readonly IProjectService _projectService;
    private readonly IWebHostEnvironment _env;
    private readonly IMapper _mapper;

    public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager, IMapper mapper, IDeveloperService developer, IWebHostEnvironment env, IProjectService projectService)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
        _mapper = mapper;
        _developer = developer;
        _env = env;
        _projectService = projectService;
    }
   /* public async Task<IActionResult> Index()
    {
        await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
        await _roleManager.CreateAsync(new IdentityRole { Name = "User" });
        await _roleManager.CreateAsync(new IdentityRole { Name = "Developer" });
        return Json("Ok");
    }*/
    public async Task<IActionResult> Register()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(RegisterVM registerVM)
    {
        if (!ModelState.IsValid) { return View(); }
        if (registerVM is null) return View(registerVM);
        AppUser appUser = new AppUser { Email = registerVM.Mail, UserName = registerVM.Username, isDeveloper = registerVM.isDeveloper };
        IdentityResult result;
        if (!ModelState.IsValid)
        {

            return View(registerVM);
        }


        result = await _userManager.CreateAsync(appUser, registerVM.Password);
        if (!result.Succeeded)
        {
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
                return View(registerVM);
            }
        }
        if (registerVM.isDeveloper)
        {
            result = await _userManager.AddToRoleAsync(appUser, "Developer");
            Developer developer = new Developer()
            {
                AppUserId = appUser.Id,
                AppUser = appUser,
            };
            await _developer.CreateAsync(_mapper.Map<DeveloperPostVM>(developer));
        }
        else
            result = await _userManager.AddToRoleAsync(appUser, "User");
        if (!result.Succeeded)
        {
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
                return View(registerVM);
            }
        }
        //Email Confirm
        string token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
        string? link = Url.Action(nameof(VerifyEmail), "Account", new { email = appUser.Email, token = token }, Request.Scheme, Request.Host.ToString());
        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress("finalproject291@gmail.com", "FinalProject");
        mailMessage.To.Add(appUser.Email);
        mailMessage.Subject = "Verify mail";
        mailMessage.Body = link;
        SmtpClient smtpClient = new SmtpClient();
        smtpClient.Host = "smtp.gmail.com";
        smtpClient.Port = 587;
        smtpClient.EnableSsl = true;
        smtpClient.Credentials = new NetworkCredential("finalproject291@gmail.com", "dsuctplefzbvcwii");
        smtpClient.Send(mailMessage);
        return RedirectToAction(nameof(Login));
    }
    public async Task<IActionResult> VerifyEmail(string email, string token)
    {
        AppUser appUser = await _userManager.FindByEmailAsync(email);
        if (appUser is null) NotFound();
        await _userManager.ConfirmEmailAsync(appUser, token);
        await _signInManager.SignInAsync(appUser, true);
        return Json("Account is active!");
    }
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
        /*if (!existUser.EmailConfirmed)
        {
            ModelState.AddModelError("", "Mail is not verified!");
            return View(loginDto);
        }*/
        if (!result.Succeeded)
        {
            ModelState.AddModelError("", "Username or password incorrect!");
            return View(loginVM);
        }
        return RedirectToAction("Index", "Home");
    }
    public async Task<IActionResult> ForgetPassword()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> ForgetPassword(ResetPasswordVM resetPasswordVM)
    {
        AppUser appUser = await _userManager.FindByEmailAsync(resetPasswordVM.Mail);
        if (appUser is null) return NotFound();
        string token = await _userManager.GeneratePasswordResetTokenAsync(appUser);
        string? link = Url.Action(nameof(ResetPasswordVM), "Account", new { email = appUser.Email, token = token }, Request.Scheme, Request.Host.ToString());
        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress("finalproject864@gmail.com", "FinalProject");
        mailMessage.To.Add(appUser.Email);
        mailMessage.Subject = "Reset password";
        mailMessage.Body = link;
        SmtpClient smtpClient = new SmtpClient();
        smtpClient.Host = "smtp.gmail.com";
        smtpClient.Port = 587;
        smtpClient.EnableSsl = true;
        smtpClient.Credentials = new NetworkCredential("finalproject864@gmail.com", "xgvscabcgzraekyv");
        smtpClient.Send(mailMessage);
        return RedirectToAction("index", "home");
    }
    public async Task<IActionResult> ResetPassword(string email, string token)
    {
        AppUser appUser = await _userManager.FindByEmailAsync(email);
        if (appUser is null) return NotFound();
        ResetPasswordVM resetPasswordVM = new ResetPasswordVM()
        {
            Mail = email,
            Token = token
        };
        return View(resetPasswordVM);
    }
    [HttpPost]
    public async Task<IActionResult> ResetPassword(ResetPasswordVM resetPasswordVM)
    {
        AppUser appUser = await _userManager.FindByEmailAsync(resetPasswordVM.Mail);
        if (appUser is null) NotFound();
        IdentityResult identityResult = await _userManager.ResetPasswordAsync(appUser, resetPasswordVM.Token, resetPasswordVM.Password);
        if (!identityResult.Succeeded)
        {
            foreach (var item in identityResult.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
            return View(resetPasswordVM);
        }
        return RedirectToAction("login", "account");
    }
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
    public async Task<IActionResult> DeveloperProfile()
    {
        var user = await _userManager.GetUserAsync(User);
        DeveloperGetVM userProfile = await _developer.GetByIdAsync(user.Id);
        userProfile.Email = user.Email;
        userProfile.UserName = user.UserName;
        return View(userProfile);
    }
    [Authorize(Roles = "Developer")]
    public async Task<IActionResult> DeveloperEdit()
    {
        var user = await _userManager.GetUserAsync(User);
        DeveloperGetVM userProfile = await _developer.GetByIdAsync(user.Id);
        DeveloperEditVM developerEdit = new DeveloperEditVM()
        {
            GetVM = userProfile
        };
        return View(developerEdit);
    }
    [HttpPost]
    public async Task<IActionResult> DeveloperEdit(DeveloperEditVM developer)
    {
        var user = await _userManager.GetUserAsync(User);
        DeveloperGetVM userProfile = await _developer.GetByIdAsync(user.Id);
        developer.GetVM = _mapper.Map<DeveloperGetVM>(userProfile);
        if (userProfile == null) return NotFound();
        user.Developer.AppUser.PhoneNumber = developer.PostVM.AppUser.PhoneNumber;
        user.Developer.AppUser.Adress = developer.PostVM.AppUser.Adress;
        user.Developer.AppUser.Surname = developer.PostVM.AppUser.Surname;
        user.Developer.AppUser.Name = developer.PostVM.AppUser.Name;
        user.Developer.Position = developer.PostVM.Position;
        if (developer.PostVM.FormFile != null)
            user.Developer.AppUser.ProfileImage = developer.PostVM.FormFile.UploadFile(_env.WebRootPath, "assets/img/");
        DeveloperPostVM developerPost = _mapper.Map<DeveloperPostVM>(user.Developer);
        await _developer.UpdateAsync(user.Developer.Id, developerPost);
        //AddProject
        if(developer.PostVM.Projects.FirstOrDefault().Name is not null)
        {
            Project project = new Project()
            {
                AuthorName = user.UserName,
                CreatedDate = developer.PostVM.Projects.FirstOrDefault().CreatedDate,
                Name = developer.PostVM.Projects.FirstOrDefault()?.Name,
                ProjectUrl = developer.PostVM.Projects.FirstOrDefault().ProjectUrl,
                Developer = user.Developer,
                Description = developer.PostVM.Projects.FirstOrDefault().Description,
                DeveloperId = user.Developer.Id,
            };
            if (developer.PostVM.Projects.FirstOrDefault().FormFile is not null)
            {
                project.Image = developer.PostVM.Projects.FirstOrDefault().FormFile.UploadFile(_env.WebRootPath, "assets/img/");

            }
            ProjectPostVM postVM = _mapper.Map<ProjectPostVM>(project);
            await _projectService.CreateAsync(postVM);
        }
       
        return RedirectToAction("DeveloperProfile", "Account");
    }
    public async Task<IActionResult> DeleteProject(int id)
    {
        await _projectService.DeleteByIdAsync(id);
        return RedirectToAction("DeveloperProfile", "Account");
    }
    public async Task<IActionResult> UserProfile()
    {
        var user = await _userManager.GetUserAsync(User);
        return View(user);
    }
    [Authorize(Roles = "User")]
    public async Task<IActionResult> UserEdit()
    {
        var user = await _userManager.GetUserAsync(User);
        return View(user);
    }
    [HttpPost]
    public async Task<IActionResult> UserEdit(AppUser user)
    {
        var editedUser = await _userManager.GetUserAsync(User);
        if (editedUser == null) return NotFound();
        editedUser.PhoneNumber = user.PhoneNumber;
        editedUser.Adress = user.Adress;
        editedUser.Surname = user.Surname;
        editedUser.Name = user.Name;
        if (user.FormFile != null)
            editedUser.ProfileImage = user.FormFile.UploadFile(_env.WebRootPath, "assets/img/");
        await _userManager.UpdateAsync(editedUser);
        return RedirectToAction("UserProfile", "Account");
    }

}