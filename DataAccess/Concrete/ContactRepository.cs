using Core.DAL.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entity.Concrete;

namespace DataAccess.Concrete;

public class ContactRepository : BaseRepository<Contact, AppDbContext>, IContactRepository
{
    public ContactRepository(AppDbContext context) : base(context)
    {
    }
}
