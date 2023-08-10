using Guru.DAL.DbContexts;
using Guru.DAL.IRepositories;
using Guru.Domain.Entities.Projects;

namespace Guru.DAL.Repositories;

public class ProjectRepository : Repository<Project>, IProjectRepository
{
    public ProjectRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
