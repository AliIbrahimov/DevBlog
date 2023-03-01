using Core.DAL.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entity.Concrete;

namespace DataAccess.Concrete;

public class AboutRepository : BaseRepository<About, AppDbContext>, IAboutRepository
{
    public AboutRepository(AppDbContext context) : base(context)
    {
    }
}
