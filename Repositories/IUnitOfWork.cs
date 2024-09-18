namespace Repositories;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}
