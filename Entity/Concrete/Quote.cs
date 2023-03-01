using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Entity.Concrete;

public class Quote
{
    public int Id { get; set; }
    [NotNull]
    public string? Message { get; set; }
    [DefaultValue("false")]
    public bool? IsActive { get; set; }
    public string? AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
}
