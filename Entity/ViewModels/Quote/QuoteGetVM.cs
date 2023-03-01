using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Entity.ViewModels.Quote;

public class QuoteGetVM
{
    public int Id { get; set; }
    [NotNull]
    public string? Message { get; set; }
    [DefaultValue("false")]
    public bool? IsActive { get; set; }
    public string? AppUserId { get; set; }
    public Concrete.AppUser? AppUser { get; set; }
}
