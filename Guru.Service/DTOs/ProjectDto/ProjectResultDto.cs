using Guru.Domain.Entities.Users;
using Guru.Domain.Enums.ProjectStatuses;

namespace Guru.Service.DTOs.ProjectDto;

public class ProjectResultDto
{
    public long Id { get; set; }
    public string ProjectName { get; set; }
    public long ClientId { get; set; }
    public User User { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Description { get; set; }
    public ProjectStatus Status { get; set; }
}
