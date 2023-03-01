namespace Entity.Concrete;

public class Service
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Title { get; set; }
    public List<ServiceAction>? ServiceActions { get; set; }
}
