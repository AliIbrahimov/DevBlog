using AutoMapper;
using Business.Abstract;
using Entity.Concrete;
using Entity.ViewModels.Quote;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithNTierArch.Areas.admin.Controllers;
[Area("admin")]
public class QuoteController : Controller
{
    private readonly IQuoteService _quoteService;
    private readonly IMapper _mapper;

    public QuoteController(IQuoteService quoteService, IMapper mapper)
    {
        _quoteService = quoteService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        List<QuoteGetVM> quotes = await _quoteService.GetAllAsync();
        return View(quotes);
    }
    public async Task<IActionResult> ActiveQuote(int id)
    {
        QuoteGetVM quote = await _quoteService.GetByIdAsync(id);
        quote.IsActive = true;
        QuotePostVM quotePost = _mapper.Map<QuotePostVM>(quote);
        await _quoteService.UpdateAsync(quote.Id, quotePost);
        return RedirectToAction("index", "quote");
    }
    public async Task<IActionResult> PassiveQuote(int id)
    {
        QuoteGetVM quote = await _quoteService.GetByIdAsync(id);
        quote.IsActive = false;
        QuotePostVM quotePost = _mapper.Map<QuotePostVM>(quote);
        await _quoteService.UpdateAsync(quote.Id,quotePost);
        return RedirectToAction("index", "quote");
    }
}
