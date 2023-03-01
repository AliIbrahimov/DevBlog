namespace Entity.Concrete;

public class ChooseUsAction
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Icon { get; set; }
    public int ChooseUsId { get; set; }
    public ChooseUs? ChooseUs { get; set; }
}
