using Guru.DAL.DbContexts;
using Guru.DAL.IRepositories;
using Guru.Domain.Entities.Messages;

namespace Guru.DAL.Repositories;

public class MesseageRepository : Repository<Message>, IMessageRepository
{
    public MesseageRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
