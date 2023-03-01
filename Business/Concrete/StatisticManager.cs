using AutoMapper;
using Business.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
using Entity.ViewModels.Developer;
using Entity.ViewModels.Slider;
using Entity.ViewModels.Statistic;
using Microsoft.AspNetCore.Hosting;

namespace Business.Concrete;

public class StatisticManager : IStatisticService
{
    private readonly IStatisticRepository _statisticRepository;
    private readonly IMapper _mapper;

    public StatisticManager(IStatisticRepository statisticRepository, IMapper mapper)
    {
        _statisticRepository = statisticRepository;
        _mapper = mapper;
    }

    public async Task<List<StatisticGetVM>> GetAllAsync()
    {
        List<Statistic> statistics = await _statisticRepository.GetAllAsync();
        if (statistics.Count is 0)
        {
            throw new NotFoundException(Messages.StatisticNotFound);
        }
        return _mapper.Map<List<StatisticGetVM>>(statistics);
    }

    public async Task<StatisticGetVM> GetByIdAsync(int id)
    {
        Statistic statistic = await _statisticRepository.GetAsync(p => p.Id==id);
        StatisticGetVM statisticGet = new StatisticGetVM()
        {
            HappyClients = statistic.HappyClients,
            HappyClientsIcon = statistic.HappyClientsIcon,
            ProjectsDone = statistic.ProjectsDone,
            ProjectsDoneIcon = statistic.ProjectsDoneIcon,
            WinAwards = statistic.WinAwards,
            WinAwardsIcon = statistic.WinAwardsIcon,
            Id = statistic.Id,
        };
        return statisticGet;
    }


    public async Task UpdateAsync(int id, StatisticPostVM sliderPost)
    {
        List<Statistic> statistic = await _statisticRepository.GetAllAsync();
        if (statistic.Count is 0)
        {
            throw new NotFoundException(Messages.StatisticNotFound);
        }
        for (int i = 0; i < statistic.Count; i++)
        {
            statistic[i].HappyClients = sliderPost.HappyClients;
            statistic[i].ProjectsDone = sliderPost.ProjectsDone;
            statistic[i].WinAwards = sliderPost.WinAwards;
            _statisticRepository.Update(statistic[i]);
        }
        await _statisticRepository.SaveAsync();
    }
}
