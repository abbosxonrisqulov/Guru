using Guru.Domain.Entities.Messages;
using Guru.Domain.Entities.Projects;
using Guru.Domain.Entities.Users;

namespace Guru.DAL.IRepositories;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }
    IProjectRepository ProjectRepository { get; }
    IMissionRepository TaskRepository { get; }
    IMessageRepository MessageRepositoy { get; }
    Task SaveAsync();
}
