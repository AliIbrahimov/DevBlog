using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Concrete;

public class AppUser:IdentityUser
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public bool isDeveloper { get; set; }
    public string? ProfileImage { get; set; }
    [NotMapped]
    public IFormFile? FormFile { get; set; }
    public string? Adress { get; set; }
    public List<Quote>? Quotes { get; set; }
    public List<Comment>? Comments { get; set; }
    public Developer? Developer { get; set; }


}
