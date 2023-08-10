using Guru.Domain.Commons;
using Guru.Domain.Entities.Projects;
using Guru.Domain.Entities.Users;
using Guru.Domain.Enums.MessageStatuses;

namespace Guru.Domain.Entities.Messages;

public class Message:Auditable
{
    public long SenderId { get; set; }
    public long  ReceiverId { get; set; }
    public User  User { get; set; }
    public long ProjectId { get; set; }
    public Project Project { get; set; }
    public MessageStatus MessadeStatus { get; set; }
    public string MessageText { get; set; }
    public DateTime TimeStamp { get; set; }= DateTime.UtcNow;

}
