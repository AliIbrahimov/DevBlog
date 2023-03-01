using Entity.ViewModels.ChooseUs;
using Entity.ViewModels.Developer;
using Entity.ViewModels.Services;

namespace Business.Abstract;

public interface IServicesService
{
    Task<List<ServicesGetVM>> GetAllAsync();

    Task<ServicesGetVM> GetByIdAsync(int id);
    Task UpdateAsync(int id, ServicesPostVM postVM);
}
