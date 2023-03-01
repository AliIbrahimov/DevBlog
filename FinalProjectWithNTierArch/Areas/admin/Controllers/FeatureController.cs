using AutoMapper;
using Business.Abstract;
using Core.Utilities.Extensions;
using Entity.Concrete;
using Entity.ViewModels.ChooseUs;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithNTierArch.Areas.admin.Controllers;

[Area("admin")]
public class FeatureController : Controller
{
    private readonly IChooseUsService _chooseUsService;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _env;

    public FeatureController(IChooseUsService chooseUsService, IMapper mapper, IWebHostEnvironment env)
    {
        _chooseUsService = chooseUsService;
        _mapper = mapper;
        _env = env;
    }

    public async Task<IActionResult> Index()
    {
        
        return View(await _chooseUsService.GetAllAsync());
    }
    public async Task<IActionResult> Edit()
    {
        ChooseUsGetVM chooseUs = await _chooseUsService.GetByIdAsync(1);
        ChooseUsEditVM editVM = new ChooseUsEditVM()
        {
            getVM = chooseUs
        };
        return View(editVM);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(ChooseUsEditVM chooseUsEdit)
    {
        var chooseUs = await _chooseUsService.GetByIdAsync(1);
        chooseUs.Name = chooseUsEdit.postVM.Name;
        chooseUs.Title = chooseUsEdit.postVM.Title;
        for (int i = 0; i < chooseUsEdit.postVM.ChooseUsActions.Count; i++)
        {
            chooseUs.ChooseUsActions[i].Name = chooseUsEdit.postVM.ChooseUsActions[i].Name;
        }
        chooseUs.FormFile = chooseUsEdit.postVM.FormFile;
        await _chooseUsService.UpdateAsync(1,_mapper.Map<ChooseUsPostVM>(chooseUs));
        return RedirectToAction("index", "Feature");
    }

}
