namespace Guru.DAL.IRepositories;

public interface IMissionRepository : IRepository<Mission>
{
    Task<Mission> GetMissionAsync(string name);
}
