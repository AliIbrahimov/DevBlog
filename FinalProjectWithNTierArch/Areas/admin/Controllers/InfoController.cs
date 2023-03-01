using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithNTierArch.Areas.admin.Controllers;
[Area("admin")]
public class InfoController : Controller
{
    private readonly ISettingService _settingService;

    public InfoController(ISettingService settingService)
    {
        _settingService = settingService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _settingService.GetAllAsync());
    }
    public async Task<IActionResult> Edit(int id)
    {
        return View(await _settingService.GetAllAsync());
    }
}
