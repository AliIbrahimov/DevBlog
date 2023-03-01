using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Concrete;

public class ChooseUs
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Title { get; set; }
    public string? Image { get; set; }
    [NotMapped]
    public IFormFile? FormFile { get; set; }
    public List<ChooseUsAction>? ChooseUsActions { get; set; }
}
