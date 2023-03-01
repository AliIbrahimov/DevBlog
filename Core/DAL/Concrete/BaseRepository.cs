using Core.DAL.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DAL.Concrete;

public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
    where TEntity : class, new()
        where TContext : IdentityDbContext<AppUser>
{
    private readonly TContext _context;

    public BaseRepository(TContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        _context.SaveChanges();
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> exp = null, params string[] includes)
    {
        IQueryable<TEntity> query = GetQuery(includes);
        return exp is null
            ? await query.ToListAsync()
            : await query.Where(exp).ToListAsync();
    }

    public async Task<List<TEntity>> GetAllPaginateAsync(int page, int size, Expression<Func<TEntity, bool>> exp = null, params string[] includes)
    {
        IQueryable<TEntity> query = GetQuery(includes);
        return exp is null
? await query.Skip((page - 1) * size).Take(size).ToListAsync()
: await query.Where(exp).Skip((page - 1) * size).Take(size).ToListAsync();
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> exp, params string[] includes)
    {
        IQueryable<TEntity> query = GetQuery(includes);
        return await query.Where(exp).FirstOrDefaultAsync();
    }

    public async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> exp)
    {
        return await _context.Set<TEntity>().AnyAsync(exp);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
    }
    private IQueryable<TEntity> GetQuery(string[] includes)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>();
        if (includes is not null)
        {
            foreach (var item in includes)
            {
                query = query.Include(item);
            }
        }
        return query;
    }
}
