using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.ViewModels.Slider;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithNTierArch.Areas.admin.Controllers;
[Area("admin")]
public class SliderController : Controller
{
    private readonly ISliderService _slider;
    private readonly IMapper _mapper;

    public SliderController(ISliderService slider, IMapper mapper)
    {
        _slider = slider;
        _mapper = mapper;
    }


    public async Task<IActionResult> Index()
    {
        List<SliderGetVM> sliderGets = await _slider.GetAllAsync();
        return View(sliderGets);
    }
    public async Task<IActionResult> Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(SliderPostVM sliderPost)
    {
        await _slider.CreateAsync(sliderPost);
        return RedirectToAction("index","SLider");
    }
    public async Task<IActionResult> Edit(int id)
    {
        SliderGetVM slider = await _slider.GetByIdAsync(id);
        SliderEditVM sliderEditVM = new SliderEditVM()
        {
            SliderGetVM = slider,
        };
        return View(sliderEditVM);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(SliderEditVM sliderEdit)
    {
        await _slider.UpdateAsync(sliderEdit.SliderGetVM.Id, sliderEdit.SliderPostVM);
        return RedirectToAction("index", "SLider");
    }
}
