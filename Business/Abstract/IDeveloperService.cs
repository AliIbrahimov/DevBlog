using Entity.ViewModels.Developer;

namespace Business.Abstract;

public interface IDeveloperService
{
    Task<List<DeveloperGetVM>> GetAllAsync();
    Task CreateAsync(DeveloperPostVM postVM);
    Task<List<DeveloperGetVM>> GetAllPaginateAsync(int page, int size);
    Task<DeveloperGetVM> GetByIdAsync(string id);
    Task UpdateAsync(int id, DeveloperPostVM postDto);
    Task DeleteByIdAsync(int id);
}
