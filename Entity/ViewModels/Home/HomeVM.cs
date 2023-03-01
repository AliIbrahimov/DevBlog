using Entity.ViewModels.Slider;
using Entity.ViewModels.Statistic;

namespace Entity.ViewModels.Home;

public class HomeVM
{
    public List<SliderGetVM>? sliderGets  { get; set; }
    public List<StatisticGetVM>? statisticGets  { get; set; }
}
