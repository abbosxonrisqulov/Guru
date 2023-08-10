using Guru.Domain.Entities.Users;

namespace Guru.DAL.IRepositories;

public interface IUserRepository : IRepository<User> 
{
    Task<User> SelectByPhone(string phoneNumber);
}
