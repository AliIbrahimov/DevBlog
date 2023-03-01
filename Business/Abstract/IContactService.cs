using Entity.ViewModels.Contact;
using Entity.ViewModels.Developer;

namespace Business.Abstract;

public interface IContactService
{
    Task<List<ContactGetVM>> GetAllAsync();
    Task CreateAsync(ContactPostVM postVM);
    Task<ContactGetVM> GetByIdAsync(int id);
    Task DeleteByIdAsync(int id);
}
