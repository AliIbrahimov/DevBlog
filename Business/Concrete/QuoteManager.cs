using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
using Entity.ViewModels.Developer;
using Entity.ViewModels.Quote;

namespace Business.Concrete;

public class QuoteManager : IQuoteService
{
    private readonly IQuoteRepository _quoteRepository;
    private readonly IMapper _mapper;

    public QuoteManager(IQuoteRepository quoteRepository, IMapper mapper)
    {
        _quoteRepository = quoteRepository;
        _mapper = mapper;
    }

    public async Task CreateAsync(QuotePostVM quotePostVM)
    {
        Quote quote = _mapper.Map<Quote>(quotePostVM);
        quote.Message = quotePostVM.Message;
        quote.IsActive = quotePostVM.IsActive;
        quote.AppUser = quotePostVM.AppUser;
        quote.AppUserId = quotePostVM.AppUserId;
        await _quoteRepository.CreateAsync(quote);
        await _quoteRepository.SaveAsync();
    }

    public Task DeleteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<QuoteGetVM>> GetAllAsync()
    {
        List<Quote> quotes = await _quoteRepository.GetAllAsync(null, "AppUser");
        return _mapper.Map<List<QuoteGetVM>>(quotes);
    }

    public Task<List<QuoteGetVM>> GetAllPaginateAsync(int page, int size)
    {
        throw new NotImplementedException();
    }

    public async Task<QuoteGetVM> GetByIdAsync(int id)
    {
        Quote quote = await _quoteRepository.GetAsync(p=>p.Id==id,"AppUser" );
        QuoteGetVM quoteGet = new QuoteGetVM()
        {
            Message = quote.Message,
            AppUser = quote.AppUser,
            IsActive = quote.IsActive,
            Id = quote.Id,
            AppUserId= quote.AppUserId
        };
        return quoteGet;
    }

    public async Task UpdateAsync(int id,QuotePostVM quotePostVM)
    {
        Quote quote = await _quoteRepository.GetAsync(p => p.Id == id,"AppUser");
        quote.IsActive = quotePostVM.IsActive;
         _quoteRepository.Update(quote);
        await _quoteRepository.SaveAsync();

    }
}
