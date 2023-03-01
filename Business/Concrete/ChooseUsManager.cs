using AutoMapper;
using Business.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions;
using Core.Utilities.Extensions;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.ViewModels.About;
using Entity.ViewModels.ChooseUs;
using Microsoft.AspNetCore.Hosting;

namespace Business.Concrete;

public class ChooseUsManager : IChooseUsService
{
    private readonly IChooseUsRepository _chooseUsRepo;
    private readonly IMapper mapper;
    private readonly IWebHostEnvironment _env;

    public ChooseUsManager(IChooseUsRepository chooseUsRepo, IMapper mapper, IWebHostEnvironment env)
    {
        _chooseUsRepo = chooseUsRepo;
        this.mapper = mapper;
        _env = env;
    }

    public async Task<List<ChooseUsGetVM>> GetAllAsync()
    {
        List<ChooseUs> chooses = await _chooseUsRepo.GetAllAsync(null,"ChooseUsActions");
        List<ChooseUsGetVM> chooseUs = mapper.Map<List<ChooseUsGetVM>>(chooses);
        return (chooseUs);
    }

    public async Task<ChooseUsGetVM> GetByIdAsync(int id)
    {
        ChooseUs chooseUs = await _chooseUsRepo.GetAsync(p => p.Id == id, "ChooseUsActions");
        if (chooseUs is null)
        {
            throw new NotFoundException(Messages.SliderNotFound);
        }

        return mapper.Map<ChooseUsGetVM>(chooseUs);
    }

    public async Task UpdateAsync(int id, ChooseUsPostVM postVM)
    {
        ChooseUs chooseUs = await _chooseUsRepo.GetAsync(p => p.Id == id, "ChooseUsActions");
        if (chooseUs is null)
        {
            throw new NotFoundException(Messages.StatisticNotFound);
        }
        chooseUs.Title = postVM.Title;
        chooseUs.Name = postVM.Name;
        for (int i = 0; i < chooseUs.ChooseUsActions.Count; i++)
        {
            chooseUs.ChooseUsActions[i].Name = postVM.ChooseUsActions[i].Name;
            chooseUs.ChooseUsActions[i].Description = postVM.ChooseUsActions[i].Description;
        }

        if (postVM.FormFile != null)
        {
            chooseUs.Image = postVM.FormFile.UploadFile(_env.WebRootPath, "assets/img");

        }//USING HELPER
        _chooseUsRepo.Update(chooseUs);
        await _chooseUsRepo.SaveAsync();
    }
}
