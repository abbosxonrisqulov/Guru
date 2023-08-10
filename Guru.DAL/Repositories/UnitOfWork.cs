using Guru.DAL.DbContexts;
using Guru.DAL.IRepositories;
using Guru.Domain.Entities.Messages;
using Guru.Domain.Entities.Projects;
using Guru.Domain.Entities.Users;

namespace Guru.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext appDbContext;

    public UnitOfWork()
    {
        appDbContext = new AppDbContext();
        UserRepository = new UserRepository(appDbContext);
        ProjectRepository = new ProjectRepository(appDbContext);
        MessageRepositoy = new MesseageRepository(appDbContext);
        TaskRepository = new MissionRepository(appDbContext);
    }
    public IUserRepository UserRepository { get; }

    public IProjectRepository ProjectRepository { get; }

    public  IMissionRepository MissionRepository { get; }

    public IMissionRepository TaskRepository { get; }

    public IMessageRepository MessageRepositoy { get; }

    public void Dispose()
    {
        GC.SuppressFinalize(true);
    }

    public async Task SaveAsync()
    {
        await appDbContext.SaveChangesAsync();
    }
}
