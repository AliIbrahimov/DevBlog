using Business.Abstract;
using Entity.ViewModels.Statistic;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithNTierArch.Areas.admin.Controllers;

[Area("admin")]
public class StatisticController : Controller
{
    private readonly IStatisticService _statisticService;

    public StatisticController(IStatisticService statisticService)
    {
        _statisticService = statisticService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _statisticService.GetAllAsync());
    }
    public async Task<IActionResult> Edit()
    {
        StatisticGetVM statisticGetVM = await _statisticService.GetByIdAsync(1);
        StatisticEditVM statisticEditVM = new StatisticEditVM()
        {
            StatisticGets = statisticGetVM
        };
        return View(statisticEditVM);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(StatisticEditVM statisticEdit)
    {
        await _statisticService.UpdateAsync(statisticEdit.StatisticGets.Id, statisticEdit.StatisticPost);
        return RedirectToAction("index", "statistic");
    }
}
