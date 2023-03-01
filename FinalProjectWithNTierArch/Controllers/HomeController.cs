using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
using Entity.ViewModels.Home;
using Entity.ViewModels.Quote;
using Entity.ViewModels.Slider;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithNTierArch.Controllers;

public class HomeController : Controller
{
    private readonly ISliderService _sliderService;
    private readonly IStatisticService _statisticService;
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IQuoteService _quoteService;


    public HomeController(ISliderService sliderService, IStatisticService statisticService, UserManager<AppUser> userManager, IMapper mapper, IQuoteService quoteService)
    {
        _sliderService = sliderService;
        _statisticService = statisticService;
        _userManager = userManager;
        _mapper = mapper;
        _quoteService = quoteService;
    }

    public async Task<IActionResult> Index()
    {
        HomeVM homeVM = new HomeVM()
        {
            sliderGets = await _sliderService.GetAllAsync(),
            statisticGets = await _statisticService.GetAllAsync(),
        };
        return View(homeVM);
    }
    [HttpPost]
    public async Task<IActionResult> Index(QuotePostVM postVM)
    {
        AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
        postVM.AppUser = appUser;
        postVM.AppUserId = appUser.Id;
        postVM.IsActive = false;
        await _quoteService.CreateAsync(postVM);
        return RedirectToAction("index", "home");
    }
    public IActionResult Error()
    {
        return View();
    }

}
