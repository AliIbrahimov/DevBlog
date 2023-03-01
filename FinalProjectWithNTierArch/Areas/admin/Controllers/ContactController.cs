using Business.Abstract;
using Entity.Concrete;
using Entity.ViewModels.Contact;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithNTierArch.Areas.admin.Controllers;
[Area("admin")]
public class ContactController : Controller
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    public async  Task<IActionResult> Index()
    {
        List<ContactGetVM> contacts = await _contactService.GetAllAsync();
        return View(contacts);
    }
    public async Task<IActionResult> Delete(int id)
    {
        ContactGetVM contact =await  _contactService.GetByIdAsync(id);
        await _contactService.DeleteByIdAsync(id);
        return RedirectToAction("index", "delete");
    }
}
