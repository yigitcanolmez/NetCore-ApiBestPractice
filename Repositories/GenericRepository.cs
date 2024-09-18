using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repositories;

public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T>
    where T : class
{
    protected AppDbContext Context = context;

    private readonly DbSet<T> _dbSet = context.Set<T>();

    public async ValueTask AddAsync(T entity) => await _dbSet.AddAsync(entity);

    public void Delete(T entity) => _dbSet.Remove(entity);

    public IQueryable<T> GetAll() => _dbSet.AsQueryable()
                                           .AsNoTracking();

    public async ValueTask<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

    public void Update(T entity) => _dbSet.Update(entity);

    public IQueryable<T> Where(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate)
                                                                             .AsNoTracking();
}
