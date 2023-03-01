using Entity.ViewModels.Developer;
using Entity.ViewModels.Setting;

namespace Business.Abstract;

public interface ISettingService
{
    Task<List<SettingGetVM>> GetAllAsync();
    Task<SettingGetVM> GetByIdAsync(int id);
    Task UpdateAsync(int id, SettingPostVM postVM);
}
