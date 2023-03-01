using Core.DAL.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entity.Concrete;

namespace DataAccess.Concrete;

public class SettingRepository : BaseRepository<Setting, AppDbContext>, ISettingRepository
{
    public SettingRepository(AppDbContext context) : base(context)
    {
    }
}
