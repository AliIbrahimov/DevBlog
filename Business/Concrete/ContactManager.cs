using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
using Entity.ViewModels.Contact;
using Entity.ViewModels.Developer;

namespace Business.Concrete;

public class ContactManager : IContactService
{
    private readonly IContactRepository _contactRepo;
    private readonly IMapper _mapper;

    public ContactManager(IContactRepository contactRepo, IMapper mapper)
    {
        _contactRepo = contactRepo;
        _mapper = mapper;
    }

    public async Task CreateAsync(ContactPostVM postVM)
    {
        Contact contact = _mapper.Map<Contact>(postVM);
        contact.Email = postVM.Email;
        contact.Subject = postVM.Subject;
        contact.FullName = postVM.FullName;
        contact.IsDeleted = postVM.IsDeleted;
        contact.CreatedDate = postVM.CreatedDate;
        contact.Message = postVM.Message;
        await _contactRepo.CreateAsync(contact);
        await _contactRepo.SaveAsync();
    }
    public async Task DeleteByIdAsync(int id)
    {
        Contact contact = await _contactRepo.GetAsync(p=>p.Id==id);
         _contactRepo.Delete(contact);
        await _contactRepo.SaveAsync();
    }

    public async Task<List<ContactGetVM>> GetAllAsync()
    {
        List<Contact> contacts = await _contactRepo.GetAllAsync();
        return _mapper.Map<List<ContactGetVM>>(contacts);
    }

    public async Task<ContactGetVM> GetByIdAsync(int id)
    {
        Contact contact = await _contactRepo.GetAsync(p => p.Id == id);
        ContactGetVM contactGet = new ContactGetVM()
        {
            Email = contact.Email,
            CreatedDate = contact.CreatedDate,
            FullName = contact.FullName,
            Message = contact.Message,
            Subject = contact.Subject
        };
        return contactGet;
    }
}
