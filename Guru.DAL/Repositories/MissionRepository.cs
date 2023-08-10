using Guru.DAL.DbContexts;
using Guru.DAL.IRepositories;

namespace Guru.DAL.Repositories;

public class MissionRepository : Repository<Mission>, IMissionRepository
{
    public MissionRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
