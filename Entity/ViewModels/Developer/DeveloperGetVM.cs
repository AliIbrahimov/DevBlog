using Entity.Concrete;

namespace Entity.ViewModels.Developer;

public class DeveloperGetVM
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? ProfileImage { get; set; }
    public string? Adress { get; set; }
    public List<Concrete.Quote>? Quotes { get; set; }
    public List<Concrete.Comment>? Comments { get; set; }
    public string? Position { get; set; }
    public List<Concrete.Project>? Projects { get; set; }
    public Concrete.AppUser? AppUser { get; set; }
    public string AppUserId { get; set; }
}
