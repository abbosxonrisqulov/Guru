
using Guru.Domain.Enums.ProjectStatuses;
using Guru.Domain.Enums.Roles;
using Guru.Service.DTOs.ProjectDto;
using Guru.Service.DTOs.UserDto;
using Guru.Service.Services;


ProjectUpdateDto projectCreateDto = new ProjectUpdateDto()
{
    Id=2,
    ProjectName="PlayMarket",
    StartDate=DateTime.UtcNow,
    EndDate=DateTime.UtcNow,
    ClientId=1,
    Description="test",
    Status=ProjectStatus.Ongoing
};

ProjectService projectService = new ProjectService();
var result =await projectService.SearchById(3);
Console.WriteLine(result.Data.ProjectName);


//result.Data.ToList().ForEach(x =>Console.WriteLine(x));

