using AutoMapper;
using Business.Abstract;
using Entity.Concrete;
using Entity.ViewModels.ChooseUs;
using Entity.ViewModels.Quote;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithNTierArch.ViewComponents;

public class QuoteViewComponent : ViewComponent
{
    private readonly IQuoteService _service;
    private readonly IMapper _mapper;

    public QuoteViewComponent(IQuoteService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        QuotePostVM quotePosts = new QuotePostVM();

        return View(quotePosts);
    }
}
