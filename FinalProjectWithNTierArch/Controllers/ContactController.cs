using AutoMapper;
using Business.Abstract;
using Entity.Concrete;
using Entity.ViewModels.Contact;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithNTierArch.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ContactPostVM contactPost)
        {
            await _contactService.CreateAsync(contactPost);
            return View();
        }
    }
}
