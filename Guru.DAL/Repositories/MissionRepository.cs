using Guru.DAL.DbContexts;
using Guru.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Guru.DAL.Repositories;

public class MissionRepository : Repository<Mission>, IMissionRepository
{
    private readonly AppDbContext dbContext;
    public MissionRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        this.dbContext = appDbContext;
    }

    public async Task<Mission> GetMissionAsync(string name)
        => await dbContext.Tasks.FirstOrDefaultAsync(x => x.TaskName.Equals(name));
}
