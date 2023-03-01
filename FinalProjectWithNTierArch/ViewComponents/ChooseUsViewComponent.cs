using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.ViewModels.ChooseUs;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithNTierArch.ViewComponents
{
    public class ChooseUsViewComponent : ViewComponent
    {
        private readonly IChooseUsService _chooseUsService;
        private readonly IMapper _mapper;

        public ChooseUsViewComponent(IChooseUsService chooseUsService, IMapper mapper)
        {
            _chooseUsService = chooseUsService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ChooseUsGetVM chooseUsGet = await _chooseUsService.GetByIdAsync(1);
            return View(chooseUsGet);
        }
    }
}
