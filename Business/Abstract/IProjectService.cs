using Entity.ViewModels.Developer;
using Entity.ViewModels.Project;

namespace Business.Abstract;

public interface IProjectService
{
    Task<List<ProjectGetVM>> GetAllAsync();
    Task CreateAsync(ProjectPostVM postVM);

    Task<List<ProjectGetVM>> GetAllPaginateAsync(int page, int size);
    Task<ProjectGetVM> GetByIdAsync(int id);
    Task UpdateAsync(int id, ProjectPostVM postDto);
    Task DeleteByIdAsync(int id);
}
