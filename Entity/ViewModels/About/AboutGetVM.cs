using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.ViewModels.About;

public class AboutGetVM
{
    public int Id { get; set; }
    public string? AboutName { get; set; }
    public string? AboutTitle { get; set; }
    public string? Aboutdescription { get; set; }
    public string? Image { get; set; }
    [NotMapped]
    public IFormFile? FormFile { get; set; }
    public List<AboutAction>? AboutActions { get; set; }
}
