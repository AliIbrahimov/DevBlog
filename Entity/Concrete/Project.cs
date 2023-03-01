using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;

namespace Entity.Concrete;

public class Project
{
    public Project()
    {
        CreatedDate = DateTime.Now;
    }
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
    public Developer? Developer { get; set; }
    public List<Comment>? Comments { get; set; }
}
