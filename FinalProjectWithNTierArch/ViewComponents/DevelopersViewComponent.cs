using Business.Abstract;
using Entity.ViewModels.ChooseUs;
using Entity.ViewModels.Developer;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithNTierArch.ViewComponents;

public class DevelopersViewComponent : ViewComponent
{
    private readonly IDeveloperService _developerService;

    public DevelopersViewComponent(IDeveloperService developerService)
    {
        _developerService = developerService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        List<DeveloperGetVM> developers = await _developerService.GetAllAsync();
        developers = developers
              .OrderByDescending(d => d.Id)
              .Take(3)
              .ToList();
        return View(developers);
    }
}
