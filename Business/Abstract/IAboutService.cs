using Entity.ViewModels.About;
using Entity.ViewModels.Slider;

namespace Business.Abstract;

public interface IAboutService
{
    Task<List<AboutGetVM>> GetAllAsync();
    Task<AboutGetVM> GetByIdAsync(int id);
    Task UpdateAsync(int id, AboutPostVM aboutPost);
}
