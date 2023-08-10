using Guru.Domain.Entities.Projects;

namespace Guru.DAL.IRepositories;

public interface IProjectRepository : IRepository<Project>
{
    Task<Project> GetByName(string name);
}
