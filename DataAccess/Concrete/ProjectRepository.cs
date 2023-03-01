using Core.DAL.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entity.Concrete;

namespace DataAccess.Concrete;

public class ProjectRepository : BaseRepository<Project, AppDbContext>, IProjectRepository
{
    public ProjectRepository(AppDbContext context) : base(context)
    {
    }
}
