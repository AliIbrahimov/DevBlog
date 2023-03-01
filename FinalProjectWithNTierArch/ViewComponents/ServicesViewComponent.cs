using AutoMapper;
using Business.Abstract;
using Entity.Concrete;
using Entity.ViewModels.ChooseUs;
using Entity.ViewModels.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithNTierArch.ViewComponents
{
    public class ServicesViewComponent : ViewComponent
    {
        private readonly IServicesService _servicesService;
        private readonly IMapper _mapper;

        public ServicesViewComponent(IServicesService servicesService, IMapper mapper)
        {
            _servicesService = servicesService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ServicesGetVM serviceGet = await _servicesService.GetByIdAsync(1);
            return View(serviceGet);
        }
    }
}
