using Core.DAL.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entity.Concrete;

namespace DataAccess.Concrete;

public class StatisticRepository : BaseRepository<Statistic, AppDbContext>, IStatisticRepository
{
    public StatisticRepository(AppDbContext context) : base(context)
    {
    }
}
