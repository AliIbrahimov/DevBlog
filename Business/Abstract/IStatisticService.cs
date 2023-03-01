using Entity.ViewModels.Developer;
using Entity.ViewModels.Slider;
using Entity.ViewModels.Statistic;

namespace Business.Abstract;

public interface IStatisticService
{
    Task<List<StatisticGetVM>> GetAllAsync();
    Task<StatisticGetVM> GetByIdAsync(int id);

    Task UpdateAsync(int id, StatisticPostVM sliderPost);
}
