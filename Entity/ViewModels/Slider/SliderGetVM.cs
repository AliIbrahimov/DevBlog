using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.ViewModels.Slider;

public class SliderGetVM
{
    public int Id { get; set; }
    public string? Image { get; set; }
    public string? Title { get; set; }
    public string? Text { get; set; }
    [NotMapped]
    public IFormFile? FormFile { get; set; }
    [DefaultValue(false)]
    public bool IsActive { get; set; }
}
