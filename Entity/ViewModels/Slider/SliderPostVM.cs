using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Entity.ViewModels.Slider;

public class SliderPostVM
{
    public string? Image { get; set; }
    public string? Title { get; set; }
    public string? Text { get; set; }
    public IFormFile? FormFile { get; set; }
    [DefaultValue(false)]
    public bool IsActive { get; set; }
}
