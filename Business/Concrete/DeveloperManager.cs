using AutoMapper;
using Business.Abstract;
using Core.Utilities.Extensions;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.ViewModels.Developer;
using Microsoft.AspNetCore.Hosting;

namespace Business.Concrete;
public class DeveloperManager : IDeveloperService
{
    private readonly IDeveloperRepository _developerRepository;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _env;

    public DeveloperManager(IDeveloperRepository developerRepository, IMapper mapper, IWebHostEnvironment env)
    {
        _developerRepository = developerRepository;
        _mapper = mapper;
        _env = env;
    }

    public async Task CreateAsync(DeveloperPostVM postVM)
    {
        Developer developer = _mapper.Map<Developer>(postVM);
        developer.AppUserId = postVM.AppUserId;
        developer.AppUser.UserName = postVM.AppUser.UserName;
        developer.AppUser.Email = postVM.AppUser.Email;
        await _developerRepository.CreateAsync(developer);
        await _developerRepository.SaveAsync();
    }

    public Task DeleteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<DeveloperGetVM>> GetAllAsync()
    {
        List<Developer> developers =await _developerRepository.GetAllAsync(p=>p.AppUser.EmailConfirmed==true,"AppUser","Projects");
        return _mapper.Map<List<DeveloperGetVM>>(developers);

    }

    public Task<List<DeveloperGetVM>> GetAllPaginateAsync(int page, int size)
    {
        throw new NotImplementedException();
    }

    public async Task<DeveloperGetVM> GetByIdAsync(string id)
    {
        Developer developer = await _developerRepository.GetAsync(p => p.AppUserId == id,"AppUser","Projects");
        DeveloperGetVM developerGet = new DeveloperGetVM()
        {
            Adress = developer.AppUser.Adress,
            Email = developer.AppUser.Email,
            PhoneNumber = developer.AppUser.PhoneNumber,
            Position = developer.Position,
            Name = developer.AppUser.Name,
            Surname = developer.AppUser.Surname,
            UserName = developer.AppUser.UserName,
            ProfileImage = developer.AppUser.ProfileImage,
            Comments = developer.AppUser.Comments,
            Projects = developer.Projects,
            Quotes = developer.AppUser.Quotes
        };
        return developerGet;
    }


    public async Task UpdateAsync(int id, DeveloperPostVM postVM)
    {
        Developer developer = await _developerRepository.GetAsync(p => p.Id == id, "AppUser");

        if (postVM.FormFile != null)
        {
            developer.AppUser.ProfileImage = postVM.FormFile.UploadFile(_env.WebRootPath, "assets/img");

        }//USING HELPER
        developer.AppUser.Adress = postVM.AppUser.Adress;
        developer.AppUser.PhoneNumber = postVM.AppUser.PhoneNumber;
        developer.AppUser.Name = postVM.AppUser.Name;
        developer.AppUser.Surname = postVM.AppUser.Surname;
        _developerRepository.Update(developer);
        await _developerRepository.SaveAsync();

    }
}
