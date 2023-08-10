using Guru.Domain.Entities.Messages;
using Guru.Domain.Enums.Roles;

namespace Guru.Service.DTOs.UserDto;

public class UserCreateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NickName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
    public string Phone { get; set; }
    public string Bio { get; set; }
    public ICollection<Message> Messages { get; set; }
    public ICollection<Mission> Tasks { get; set; }
}
