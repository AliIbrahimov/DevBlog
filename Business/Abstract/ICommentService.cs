using Entity.ViewModels.Comment;
using Entity.ViewModels.Developer;
using Entity.ViewModels.Project;

namespace Business.Abstract;

public interface ICommentService
{
    Task<List<CommentGetVM>> GetAllAsync();
    Task CreateAsync(CommentPostVM postVM);


}
