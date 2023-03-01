using Business.Abstract;
using Entity.Concrete;
using Entity.ViewModels.About;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithNTierArch.Areas.admin.Controllers;

[Area("admin")]
public class AboutController : Controller
{
    private readonly IAboutService _aboutService;

    public AboutController(IAboutService aboutService)
    {
        _aboutService = aboutService;
    }

    public async Task<IActionResult> Index()
    {

        return View(await _aboutService.GetAllAsync());
    }   
    public async Task<IActionResult> Edit(int id)
    {
        AboutGetVM about = await _aboutService.GetByIdAsync(id);
        AboutEditVM aboutEdit = new AboutEditVM()
        {
            getVM = about
        };
        return View(aboutEdit);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(AboutEditVM aboutEdit)
    {
        await _aboutService.UpdateAsync(1,aboutEdit.postVM);
        return RedirectToAction("index", "about");
    }
}
