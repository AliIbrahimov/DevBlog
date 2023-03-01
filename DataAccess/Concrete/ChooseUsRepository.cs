using Core.DAL.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entity.Concrete;

namespace DataAccess.Concrete;

public class ChooseUsRepository : BaseRepository<ChooseUs, AppDbContext>, IChooseUsRepository
{
    public ChooseUsRepository(AppDbContext context) : base(context)
    {
    }
}
