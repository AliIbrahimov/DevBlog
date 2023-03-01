using Entity.ViewModels.Quote;

namespace Business.Abstract;

public interface IQuoteService
{
    Task<List<QuoteGetVM>> GetAllAsync();
    Task<List<QuoteGetVM>> GetAllPaginateAsync(int page, int size);
    Task<QuoteGetVM> GetByIdAsync(int id);
    Task CreateAsync(QuotePostVM quotePostVM);
    Task UpdateAsync(int id,QuotePostVM quotePostVM);
    Task DeleteByIdAsync(int id);
}
