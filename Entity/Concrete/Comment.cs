using System.Diagnostics.CodeAnalysis;

namespace Entity.Concrete;

public class Comment
{
    public Comment()
    {
        SendedDate = DateTime.Now;
    }
    public int Id { get; set; }
    public string? AppUserId { get; set; }
    public int? ProjectId { get; set; }
    [NotNull]

    public string? Message { get; set; }
    public DateTime SendedDate { get; set; }
    public bool isDeleted { get; set; }
    public AppUser? AppUser { get; set; }
    public Project? Project { get; set; }
}
