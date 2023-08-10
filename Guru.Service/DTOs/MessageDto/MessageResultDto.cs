using Guru.Domain.Entities.Projects;
using Guru.Domain.Entities.Users;
using Guru.Domain.Enums.MessageStatuses;

namespace Guru.Service.DTOs.MessageDto;

public class MessageResultDto
{
    public long Id { get; set; }
    public long SenderId { get; set; }
    public long ReceiverId { get; set; }
    public User User { get; set; }
    public long ProjectId { get; set; }
    public Project Project { get; set; }
    public MessageStatus MessadeStatus { get; set; }
    public string MessageText { get; set; }
    public DateTime TimeStamp { get; set; } = DateTime.Now;
}
