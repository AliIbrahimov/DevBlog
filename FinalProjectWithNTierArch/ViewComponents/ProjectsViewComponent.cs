using AutoMapper;
using Business.Abstract;
using Entity.ViewModels.Project;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithNTierArch.ViewComponents;

public class ProjectsViewComponent : ViewComponent
{
    private readonly IProjectService _projectService;
    private readonly IMapper _mapper;

    public ProjectsViewComponent(IProjectService projectService, IMapper mapper)
    {
        _projectService = projectService;
        _mapper = mapper;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        List<ProjectGetVM> projectGets = await _projectService.GetAllAsync();
        projectGets = projectGets
            .OrderByDescending(d => d.CreatedDate)
            .Take(3)
            .ToList();
        return View(projectGets);
    }
}
