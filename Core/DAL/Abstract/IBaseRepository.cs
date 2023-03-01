using System.Linq.Expressions;

namespace Core.DAL.Abstract;

public interface IBaseRepository<TEntity>
{
    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> exp = null, params string[] includes);
    Task<List<TEntity>> GetAllPaginateAsync(int page, int size, Expression<Func<TEntity, bool>> exp = null, params string[] includes);
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> exp, params string[] includes);
    Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> exp);
    Task CreateAsync(TEntity entity);
    Task SaveAsync();
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
