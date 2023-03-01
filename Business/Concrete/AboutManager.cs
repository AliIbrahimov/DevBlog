using AutoMapper;
using Business.Abstract;
using Business.Utilities.Constants;
using Business.Utilities.Profiles;
using Core.Utilities.Exceptions;
using Core.Utilities.Extensions;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
using Entity.ViewModels.About;
using Entity.ViewModels.Slider;
using Microsoft.AspNetCore.Hosting;

namespace Business.Concrete;

public class AboutManager : IAboutService
{
    private readonly IAboutRepository _aboutRepo;
    private readonly IMapper mapper;
    private readonly IWebHostEnvironment _env;

    public AboutManager(IAboutRepository aboutRepo, IMapper mapper, IWebHostEnvironment env)
    {
        _aboutRepo = aboutRepo;
        this.mapper = mapper;
        _env = env;
    }

    public async Task<List<AboutGetVM>> GetAllAsync()
    {
        List<About> about = await _aboutRepo.GetAllAsync(null,"AboutActions");
        if (about.Count is 0)
        {
            throw new NotFoundException(Messages.SliderNotFound);
        }
        List<AboutGetVM> aboutGets  = mapper.Map<List<AboutGetVM>>(about);
        return aboutGets;
    }

    public async Task<AboutGetVM> GetByIdAsync(int id)
    {
        About about = await _aboutRepo.GetAsync(p => p.Id == id,"AboutActions");
        if (about is null)
        {
            throw new NotFoundException(Messages.SliderNotFound);
        }

        return mapper.Map<AboutGetVM>(about);
    }

    public async Task UpdateAsync(int id, AboutPostVM postVM)
    {
        About about = await _aboutRepo.GetAsync(p=>p.Id==id, "AboutActions");
        if (about is null)
        {
            throw new NotFoundException(Messages.StatisticNotFound);
        }
        about.AboutTitle = postVM.AboutTitle;
        about.Aboutdescription = postVM.Aboutdescription;
        about.AboutName = postVM.AboutName;
        for (int i = 0; i < about.AboutActions.Count; i++)
        {
            about.AboutActions[i].Name = postVM.AboutActions[i].Name;
        }

        if (postVM.FormFile != null)
        {
            about.Image = postVM.FormFile.UploadFile(_env.WebRootPath, "assets/img");

        }//USING HELPER
        _aboutRepo.Update(about);
        await _aboutRepo.SaveAsync();
    }
}
