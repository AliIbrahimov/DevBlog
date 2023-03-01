using Core.DAL.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entity.Concrete;

namespace DataAccess.Concrete;

public class QuoteRepository : BaseRepository<Quote, AppDbContext>, IQuoteRepository
{
    public QuoteRepository(AppDbContext context) : base(context)
    {
    }
}
