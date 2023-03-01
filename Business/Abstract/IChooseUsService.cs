using Entity.ViewModels.About;
using Entity.ViewModels.ChooseUs;
using Entity.ViewModels.Developer;

namespace Business.Abstract;

public interface IChooseUsService
{
    Task<List<ChooseUsGetVM>> GetAllAsync();

    Task<ChooseUsGetVM> GetByIdAsync(int id);
    Task UpdateAsync(int id, ChooseUsPostVM postVM);
}
