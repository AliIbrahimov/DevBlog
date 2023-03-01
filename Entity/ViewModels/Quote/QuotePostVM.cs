using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Entity.ViewModels.Quote;

public class QuotePostVM
{
    [NotNull]
    public string? Message { get; set; }
    [DefaultValue("false")]
    public bool? IsActive { get; set; }
    public string? AppUserId { get; set; }
    public Concrete.AppUser? AppUser { get; set; }
}
