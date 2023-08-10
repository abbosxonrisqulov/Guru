using Guru.DAL.DbContexts;
using Guru.DAL.IRepositories;
using Guru.Domain.Commons;
using Microsoft.EntityFrameworkCore;

namespace Guru.DAL.Repositories;




public class Repository<T> : IRepository<T> where T : Auditable
{

    private readonly DbSet<T> dbset;
    public Repository(AppDbContext appDbContext)
    {
        dbset = appDbContext.Set<T>();
    }

    public async Task CreateAsync(T entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        await dbset.AddAsync(entity);
    }
    public void Update(T entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        dbset.Entry(entity).State=EntityState.Modified;
    }
    public void Delete(T entity)
    {
        dbset.Remove(entity);
    }

    public IQueryable<T> SelectAll()
        =>dbset.AsNoTracking().AsQueryable();

    public async Task<T> SelectByIdAsync(long id)
        => await dbset.FirstOrDefaultAsync(x => x.Id == id);

}
