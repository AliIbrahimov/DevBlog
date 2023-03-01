using Core.DAL.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entity.Concrete;

namespace DataAccess.Concrete;

public class ProfileRepository : BaseRepository<AppUser, AppDbContext>, IProfileRepository
{
    public ProfileRepository(AppDbContext context) : base(context)
    {
    }
}
