using AutoMapper;
using Business.Abstract;
using Entity.Concrete;
using Entity.ViewModels.ChooseUs;
using Entity.ViewModels.Quote;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithNTierArch.ViewComponents;

public class TestimonialViewComponent : ViewComponent
{
    private readonly IQuoteService _quoteService;
    private readonly IMapper _mapper;

    public TestimonialViewComponent(IQuoteService quoteService, IMapper mapper)
    {
        _quoteService = quoteService;
        _mapper = mapper;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        List<QuoteGetVM> quotes = await _quoteService.GetAllAsync();
       
        return View(quotes.Where(p => p.IsActive == true).ToList());
    }
}
