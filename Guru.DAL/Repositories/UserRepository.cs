using Guru.DAL.DbContexts;
using Guru.DAL.IRepositories;
using Guru.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Guru.DAL.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly AppDbContext dbContext;
    public UserRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        this.dbContext = appDbContext;
    }

    public async Task<User> SelectByEmail(string email)
    {
        var result = dbContext.Users.FirstOrDefault(x => x.Email.Equals(email));

        return result;
    }
       
    public async Task<User> SelectbyPassword(string password)
        =>await dbContext.Users.FirstOrDefaultAsync(x => x.Password.Equals(password));

    public async Task<User> SelectByPhone(string phoneNumber)
            => await  dbContext.Users.FirstOrDefaultAsync(x=>x.Phone.Equals(phoneNumber));
}
