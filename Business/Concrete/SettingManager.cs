using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
using Entity.ViewModels.Developer;
using Entity.ViewModels.Setting;

namespace Business.Concrete;

public class SettingManager : ISettingService
{
    private readonly ISettingRepository _settingRepository;
    private readonly IMapper _mapper;

    public SettingManager(ISettingRepository settingRepository, IMapper mapper)
    {
        _settingRepository = settingRepository;
        _mapper = mapper;
    }

    public async Task<List<SettingGetVM>> GetAllAsync()
    {
        List<Setting> settings = await _settingRepository.GetAllAsync();
        return _mapper.Map<List<SettingGetVM>>(settings);
    }

    public async Task<SettingGetVM> GetByIdAsync(int id)
    {
        Setting setting = await _settingRepository.GetAsync(p => p.Id == id);
        SettingGetVM settingGet = new SettingGetVM()
        {
            Adress = setting.Adress,
            FacebookIcon = setting.FacebookIcon,
            InstagramIcon = setting.InstagramIcon,
            LinkedinIcon = setting.LinkedinIcon,
            Mail = setting.Mail,
            Phone = setting.Phone,
            TwitterIcon = setting.TwitterIcon,
            YoutubeIcon = setting.YoutubeIcon,
            Id = setting.Id,
        };
        return settingGet;
    }

    public async Task UpdateAsync(int id, SettingPostVM postVM)
    {
        Setting setting = await _settingRepository.GetAsync(p => p.Id == id);
        setting.Adress = postVM.Adress;
        setting.FacebookIcon = postVM.FacebookIcon;
        setting.InstagramIcon = postVM.InstagramIcon;
        setting.LinkedinIcon = postVM.LinkedinIcon;
        setting.Mail = postVM.Mail;
        setting.Phone = postVM.Phone;
        setting.TwitterIcon = postVM.TwitterIcon;
        setting.YoutubeIcon = postVM.YoutubeIcon;
        await _settingRepository.SaveAsync();
    }
}
