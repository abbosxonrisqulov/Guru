using Guru.DAL.DbContexts;
using Guru.DAL.IRepositories;
using Guru.Domain.Entities.Projects;
using Microsoft.EntityFrameworkCore;

namespace Guru.DAL.Repositories;

public class ProjectRepository : Repository<Project>, IProjectRepository
{
    private readonly AppDbContext dbContext;
    public ProjectRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        this.dbContext = appDbContext;
    }

    public async Task<Project> GetByName(string name)
        => await dbContext.Projects.FirstOrDefaultAsync(x => x.ProjectName.Equals(name));
}
