using Entity.Concrete;

namespace Entity.ViewModels.Services;

public class ServicesPostVM
{
    public string? Name { get; set; }
    public string? Title { get; set; }
    public List<ServiceAction>? ServiceActions { get; set; }
}
