using AutoMapper;
using Business.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions;
using Core.Utilities.Extensions;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
using Entity.ViewModels.Project;
using Microsoft.AspNetCore.Hosting;

namespace Business.Concrete;

public class ProjectManager : IProjectService
{
    private readonly IProjectRepository _project;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _env;

    public ProjectManager(IProjectRepository project, IMapper mapper, IWebHostEnvironment env)
    {
        _project = project;
        _mapper = mapper;
        _env = env;
    }

    public async Task CreateAsync(ProjectPostVM postVM)
    {
        Project project = _mapper.Map<Project>(postVM);
        project.Name = postVM.Name;
        project.Description = postVM.Description;
        project.CreatedDate = postVM.CreatedDate;
        project.ProjectUrl = postVM.ProjectUrl;
        project.AuthorName = postVM.AuthorName;
        project.Image = postVM.Image;
/*        project.Developer = postVM.Developer;
*/       /* project.DeveloperId = postVM.Developer.Id;
        project.Developer.AppUserId = postVM.Developer.AppUserId;*/
        await _project.CreateAsync(project);
        await _project.SaveAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        Project project =await _project.GetAsync(p => p.Id == id);
        if (project is null)
        {
            throw new NotFoundException(Messages.StatisticNotFound);
        }
        _project.Delete(project);
        await _project.SaveAsync();
    }

    public async Task<List<ProjectGetVM>> GetAllAsync()
    {
        List<Project> projects = await _project.GetAllAsync(c => c.Developer.AppUser.EmailConfirmed&&!c.IsDeleted, "Comments");
        if (projects.Count is 0)
        {
            throw new NotFoundException(Messages.SliderNotFound);
        }
        return _mapper.Map<List<ProjectGetVM>>(projects);
    }

    public Task<List<ProjectGetVM>> GetAllPaginateAsync(int page, int size)
    {
        throw new NotImplementedException();
    }

    public async Task<ProjectGetVM> GetByIdAsync(int id)
    {
        Project project = await _project.GetAsync(c => c.Id == id && !c.IsDeleted,"Comments");
        if (project is null)
        {
            throw new NotFoundException(Messages.SliderNotFound);
        }
        return _mapper.Map<ProjectGetVM>(project);
    }

    public async Task UpdateAsync(int id, ProjectPostVM postDto)
    {
        Project project = await _project.GetAsync(c => c.Id == id && !c.IsDeleted);
        if (project is null)
        {
            throw new NotFoundException(Messages.SliderNotFound);
        }
        project.Name = postDto.Name;
        project.Description = postDto.Description;
        if (postDto.FormFile != null)
        {
            project.Image = postDto.FormFile.UploadFile(_env.WebRootPath, "assets/img/");

        }//USING HELPER


        _project.Update(project);
        await _project.SaveAsync();
    }
}
