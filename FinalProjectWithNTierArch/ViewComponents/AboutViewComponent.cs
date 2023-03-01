using AutoMapper;
using Business.Abstract;
using Entity.ViewModels.About;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithNTierArch.ViewComponents;

public class AboutViewComponent : ViewComponent
{
    private readonly IAboutService _aboutService;
    private readonly IMapper _mapper;

    public AboutViewComponent(IMapper mapper, IAboutService aboutService)
    {
        _mapper = mapper;
        _aboutService = aboutService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        AboutGetVM about = await _aboutService.GetByIdAsync(1);
        return View(about);
    }
}