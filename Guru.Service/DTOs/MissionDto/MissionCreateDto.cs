﻿using Guru.Domain.Entities.Projects;
using Guru.Domain.Entities.Users;
using Guru.Domain.Enums.Priorities;
using Guru.Domain.Enums.TaskStatuses;

namespace Guru.Service.DTOs.MissionDto;

public class MissionCreateDto
{
    public string TaskName { get; set; }
    public long ProjectId { get; set; }
    public Project Project { get; set; }
    public long AssignedTo { get; set; }
    public User User { get; set; }
    public DateTime DueDate { get; set; }
    public Priority Priority { get; set; }
    public Status Status { get; set; }
}
