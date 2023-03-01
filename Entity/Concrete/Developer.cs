namespace Entity.Concrete;

public class Developer
{
    public int Id { get; set; }
    public string? AppUserId { get; set; }
    public string? Position { get; set; }
    public List<Project>? Projects { get; set; }
    public AppUser? AppUser { get; set; }

}   
