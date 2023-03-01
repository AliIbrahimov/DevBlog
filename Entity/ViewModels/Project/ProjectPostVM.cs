using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Entity.ViewModels.Project;

public class ProjectPostVM
{
    public int Id { get; set; }
    public int? DeveloperId { get; set; }

    public string? Name { get; set; }
    public string? AuthorName { get; set; }
    public string? ProjectUrl { get; set; }
    public DateTime? CreatedDate { get; set; }
    [DefaultValue(false)]
    public bool IsDeleted { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    [NotMapped]
    public IFormFile? FormFile { get; set; }
    public Concrete.Developer? Developer { get; set; }
    public List<Concrete.Comment>? Comments { get; set; }
}
