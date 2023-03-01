using Business.Abstract;
using Entity.ViewModels.Developer;
using Entity.ViewModels.Pagination;
using Entity.ViewModels.Project;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithNTierArch.Controllers
{
    public class PagesController : Controller
    {
        private readonly IDeveloperService _developerService;

        public PagesController(IDeveloperService developerService)
        {
            _developerService = developerService;
        }

        public IActionResult Features()
        {
            return View();
        }
        public async Task<IActionResult> Developers(int currentpage = 1, int take = 1)
        {
            List<DeveloperGetVM> developers = await _developerService.GetAllAsync();
            int pageCount = (int)Math.Ceiling((decimal)developers.Count / take);

            developers = developers
               .OrderByDescending(d => d.Id)
               .Skip((currentpage - 1) * take)
               .Take(take)
               .ToList();
            if (pageCount == 0) pageCount = 1;

            PaginationVM<DeveloperGetVM> pagination = new PaginationVM<DeveloperGetVM>
            {
                Models = developers,
                CurrentPage = currentpage,
                PageCount = pageCount,
                NextPage = currentpage < pageCount,
                Previous = currentpage > 1
            };

            return View(pagination);
        }
        public IActionResult Testimonials()
        {
            return View();
        }
        public IActionResult Quotes()
        {
            return View();
        }
    }
}
