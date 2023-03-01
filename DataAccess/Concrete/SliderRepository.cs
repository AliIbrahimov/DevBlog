using Core.DAL.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entity.Concrete;

namespace DataAccess.Concrete;

public class SliderRepository : BaseRepository<Slider, AppDbContext>, ISliderRepository
{
    public SliderRepository(AppDbContext context) : base(context)
    {
    }
}
