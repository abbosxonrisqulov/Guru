using Guru.DAL.DbContexts;
using Guru.DAL.IRepositories;
using Guru.Domain.Entities.Users;

namespace Guru.DAL.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly AppDbContext dbContext;
    public UserRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        this.dbContext = appDbContext;
    }
    public async Task<User> SelectByPhone(string phoneNumber)
            =>  dbContext.Users.FirstOrDefault(x=>x.Phone.Equals(phoneNumber));
}
