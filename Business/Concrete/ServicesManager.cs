using AutoMapper;
using Business.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.ViewModels.ChooseUs;
using Entity.ViewModels.Services;
using Microsoft.AspNetCore.Hosting;

namespace Business.Concrete;

public class ServicesManager : IServicesService
{
    private readonly IServiceRepository _serviceRepo;
    private readonly IMapper mapper;
    private readonly IWebHostEnvironment _env;

    public ServicesManager(IServiceRepository serviceRepo, IMapper mapper, IWebHostEnvironment env)
    {
        _serviceRepo = serviceRepo;
        this.mapper = mapper;
        _env = env;
    }

    public async Task<List<ServicesGetVM>> GetAllAsync()
    {
        List<Service> services = await _serviceRepo.GetAllAsync(null, "ServiceActions");
        List<ServicesGetVM> servicesGets = mapper.Map<List<ServicesGetVM>>(services);
        return servicesGets;
    }

    public async Task<ServicesGetVM> GetByIdAsync(int id)
    {
        Service service = await _serviceRepo.GetAsync(p => p.Id == id, "ServiceActions");
        if (service is null)
        {
            throw new NotFoundException(Messages.SliderNotFound);
        }

        return mapper.Map<ServicesGetVM>(service);
    }

    public async Task UpdateAsync(int id, ServicesPostVM postVM)
    {
        Service service = await _serviceRepo.GetAsync(p => p.Id == id, "ServiceActions");
        if (service is null)
        {
            throw new NotFoundException(Messages.StatisticNotFound);
        }
        service.Name = postVM.Name;
        service.Title = postVM.Title;
        for (int i = 0; i < service.ServiceActions.Count; i++)
        {
            service.ServiceActions[i].Name = postVM.ServiceActions[i].Name;
            service.ServiceActions[i].Title = postVM.ServiceActions[i].Title;
        }
        _serviceRepo.Update(service);
        await _serviceRepo.SaveAsync();
    }
}
