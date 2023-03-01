using Entity.ViewModels.Slider;

namespace Business.Abstract;

public interface ISliderService
{
    Task<List<SliderGetVM>> GetAllAsync();
    Task<SliderGetVM> GetByIdAsync(int id);
    Task CreateAsync(SliderPostVM sliderPost);
    Task UpdateAsync(int id, SliderPostVM sliderPost);
    Task DeleteByIdAsync(int id);
}
