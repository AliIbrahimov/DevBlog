namespace Entity.Concrete;

public class ServiceAction
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Title { get; set; }
    public string? Icon { get; set; }
    public int ServiceId { get; set; }
    public Service? Service { get; set; }
}
