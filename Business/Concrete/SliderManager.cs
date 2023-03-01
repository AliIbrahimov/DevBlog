using AutoMapper;
using Business.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions;
using Core.Utilities.Extensions;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.ViewModels.Slider;
using Microsoft.AspNetCore.Hosting;

namespace Business.Concrete;

public class SliderManager : ISliderService
{
    private readonly IWebHostEnvironment _env;
    private readonly ISliderRepository _sliderRepository;
    private readonly IMapper _mapper;

    public SliderManager(IWebHostEnvironment env, IMapper mapper, ISliderRepository sliderRepository)
    {
        _env = env;
        _mapper = mapper;
        _sliderRepository = sliderRepository;
    }

    public async Task CreateAsync(SliderPostVM sliderPost)
    {
        Slider slider = _mapper.Map<Slider>(sliderPost);
        slider.Image = sliderPost.FormFile.UploadFile(_env.WebRootPath, "assets/img");
        await _sliderRepository.CreateAsync(slider);
        await _sliderRepository.SaveAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        Slider slider = await _sliderRepository.GetAsync(p => p.Id == id);
        if (slider is null)
        {
            throw new NotFoundException(Messages.SliderNotFound);
        }
        _sliderRepository.Delete(slider);
        await _sliderRepository.SaveAsync();
    }

    public async Task<List<SliderGetVM>> GetAllAsync()
    {
        List<Slider> sliders = await _sliderRepository.GetAllAsync();
        if (sliders.Count is 0)
        {
            throw new NotFoundException(Messages.SliderNotFound);
        }
        List<SliderGetVM> sliderGets = _mapper.Map<List<SliderGetVM>>(sliders);
        return sliderGets;
    }

    public async Task<SliderGetVM> GetByIdAsync(int id)
    {
        Slider slider = await _sliderRepository.GetAsync(p => p.Id == id);
        if (slider is null)
        {
            throw new NotFoundException(Messages.SliderNotFound);
        }
        return _mapper.Map<SliderGetVM>(slider);
    }

    public async Task UpdateAsync(int id, SliderPostVM sliderPost)
    {
        Slider slider = await _sliderRepository.GetAsync(p => p.Id == id);
        if (slider is null)
        {
            throw new NotFoundException(Messages.SliderNotFound);
        }
        slider.Title = sliderPost.Title;
        slider.Text = sliderPost.Text;
        

        if (sliderPost.FormFile != null)
        {
            slider.Image = sliderPost.FormFile.UploadFile(_env.WebRootPath, "assets/img");

        }//USING HELPER
        _sliderRepository.Update(slider);
        await _sliderRepository.SaveAsync();
    }
}
