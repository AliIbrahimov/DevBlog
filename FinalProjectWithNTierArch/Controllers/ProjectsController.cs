using Business.Abstract;
using Entity.Concrete;
using Entity.ViewModels.Comment;
using Entity.ViewModels.Developer;
using Entity.ViewModels.Pagination;
using Entity.ViewModels.Project;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithNTierArch.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly ICommentService _commentService;
        private readonly IDeveloperService _developerService;
        private readonly UserManager<AppUser> _userManager;

        public ProjectsController(IProjectService projectService, ICommentService commentService, UserManager<AppUser> userManager, IDeveloperService developerService)
        {
            _projectService = projectService;
            _commentService = commentService;
            _userManager = userManager;
            _developerService = developerService;
        }

        public async Task<IActionResult> AllProject(int currentpage = 1, int take = 8)
        {
            List<ProjectGetVM> projectGets =await  _projectService.GetAllAsync();
            int pageCount = (int)Math.Ceiling((decimal)projectGets.Count / take);

            projectGets = projectGets
               .OrderByDescending(d => d.CreatedDate)
               .Skip((currentpage - 1) * take)
               .Take(take)
               .ToList();
            if (pageCount == 0) pageCount = 1;

            PaginationVM<ProjectGetVM> pagination = new PaginationVM<ProjectGetVM>
            {
                Models = projectGets,
                CurrentPage = currentpage,
                PageCount = pageCount,
                NextPage = currentpage < pageCount,
                Previous = currentpage > 1
            };

            return View(pagination);
        }
        public async Task<IActionResult> Detail(int id)
        {
            ProjectGetVM project = await _projectService.GetByIdAsync(id);
            List<CommentGetVM> commentGets =await  _commentService.GetAllAsync();
            ProjectEditVM projectEdit = new ProjectEditVM()
            {
                projectGet = project,
            };
            for (int i = 0; i < project.Comments.Count; i++)
            {
                project.AppUser = await _userManager.FindByIdAsync(project.Comments[i].AppUserId);
            }
            return View(projectEdit);
        }
        [HttpPost]
        public async Task<IActionResult> Comment(CommentPostVM postVM)
        {
            AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ProjectGetVM project = await _projectService.GetByIdAsync(postVM.ProjectId);
            CommentPostVM comment = new CommentPostVM()
            {
                AppUser = appUser,
                Message = postVM.Message,
                ProjectId = postVM.ProjectId,
                AppUserId = appUser.Id,
                SendedDate = DateTime.Now,
            };
            await _commentService.CreateAsync(comment);
            postVM.AppUser = appUser;
            postVM.AppUser.Name = appUser.Name;
            postVM.AppUser.Email = appUser.Email;
            postVM.AppUser.ProfileImage = appUser.ProfileImage;


            return RedirectToAction("Detail", new { id = postVM.ProjectId });
        }
    }
}
