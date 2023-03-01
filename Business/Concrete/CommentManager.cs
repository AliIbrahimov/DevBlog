using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
using Entity.ViewModels.Comment;
using Entity.ViewModels.Developer;

namespace Business.Concrete;

public class CommentManager : ICommentService
{
    private readonly ICommentRepository _commentRepo;
    private readonly IMapper _mapper;

    public CommentManager(ICommentRepository commentRepo, IMapper mapper)
    {
        _commentRepo = commentRepo;
        _mapper = mapper;
    }

    public async Task CreateAsync(CommentPostVM postVM)
    {
        Comment comment = _mapper.Map<Comment>(postVM);
        await _commentRepo.CreateAsync(comment);
        await _commentRepo.SaveAsync();
    }

    public async Task<List<CommentGetVM>> GetAllAsync()
    {
        List<Comment> comments = await _commentRepo.GetAllAsync();
        return _mapper.Map<List<CommentGetVM>>(comments);
    }
}
