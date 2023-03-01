using System.Diagnostics.CodeAnalysis;

namespace Entity.ViewModels.Comment;

public class CommentGetVM
{
    public int Id { get; set; }

    public string AppUserId { get; set; }
    public int ProjectId { get; set; }
    [NotNull]

    public string? Message { get; set; }
    public DateTime SendedDate { get; set; }
    public bool isDeleted { get; set; }

    public Concrete.AppUser AppUser { get; set; }
    public Concrete.Project Project { get; set; }
}
