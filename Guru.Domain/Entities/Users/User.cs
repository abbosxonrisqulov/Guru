using Guru.Domain.Commons;
using Guru.Domain.Enums.Roles;
using System.Security.Cryptography.X509Certificates;

namespace Guru.Domain.Entities.Users;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NickName { get; set; }
    public string Email { get; set; }   
    public string Password { get; set; }
    public Role Role { get; set; }
    public string Phone { get; set; }
    public string Bio { get; set; }
}
