using AutoMapper;
using Business.Abstract;
using Entity.ViewModels.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithNTierArch.Areas.admin.Controllers;
[Area("admin")]
public class ServiceController : Controller
{
    private readonly IServicesService _servicesService;
    private readonly IMapper _mapper;

    public ServiceController(IServicesService servicesService, IMapper mapper)
    {
        _servicesService = servicesService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        List<ServicesGetVM> services = await _servicesService.GetAllAsync();
        return View(services);
        
    }
    public async Task<IActionResult> Edit(int id)
    {
        ServicesGetVM services = await _servicesService.GetByIdAsync(1);
        ServicesEditVM servicesEdit = new ServicesEditVM()
        {
            getVM = services
        };
        return View(servicesEdit);
        
    }
    [HttpPost]
    public async Task<IActionResult> Edit(ServicesEditVM servicesEdit)
    {
        ServicesGetVM services = await _servicesService.GetByIdAsync(1);
        services.Title = servicesEdit.postVM.Title;
        services.Name = servicesEdit.postVM.Name;
        for (int i = 0; i < servicesEdit.postVM.ServiceActions.Count; i++)
        {
            services.ServiceActions[i].Name = servicesEdit.postVM.ServiceActions[i].Name;
        }
        await _servicesService.UpdateAsync(1,_mapper.Map<ServicesPostVM>(services));
        return RedirectToAction("index", "service");
    }
}
