using Core.DAL.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entity.Concrete;

namespace DataAccess.Concrete;

public class ServiceRepository : BaseRepository<Service, AppDbContext>, IServiceRepository
{
    public ServiceRepository(AppDbContext context) : base(context)
    {
    }
}
