using Core.DAL.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entity.Concrete;

namespace DataAccess.Concrete;

public class DeveloperRepository : BaseRepository<Developer, AppDbContext>, IDeveloperRepository
{
    public DeveloperRepository(AppDbContext context) : base(context)
    {
    }
}
