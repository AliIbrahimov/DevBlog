namespace Entity.Concrete;

public class AboutAction
{
    public int Id { get; set; }
    public string? Icon { get; set; }
    public string? Name { get; set; }
    public int AboutId { get; set; }
    public About? About { get; set; }
}
