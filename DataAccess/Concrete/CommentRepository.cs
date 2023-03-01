using Core.DAL.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entity.Concrete;

namespace DataAccess.Concrete;

public class CommentRepository : BaseRepository<Comment, AppDbContext>, ICommentRepository
{
    public CommentRepository(AppDbContext context) : base(context)
    {
    }
}
