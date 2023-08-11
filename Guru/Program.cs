
using Guru.Domain.Entities.Users;
using Guru.Domain.Enums.ProjectStatuses;
using Guru.Domain.Enums.Roles;
using Guru.Service.DTOs.MessageDto;
using Guru.Service.DTOs.MissionDto;
using Guru.Service.DTOs.ProjectDto;
using Guru.Service.DTOs.UserDto;
using Guru.Service.Services;
using Guru.View;
using Guru.View.Clients;
using System.Numerics;

//View view = new View();

//view.Output();

UserCreateDto userCreateDto = new UserCreateDto()
{
    FirstName="Fayzulla",
    LastName="XAyrullayev",
    NickName="Kuyovbola",
    Email="xayrullayev@gmail.com",
    Password="1q2w3e4r",
    Role=Role.ProjectManager,
    Phone="+998998765324",
    Bio ="Project meneger"
};

UserService userService = new UserService();

await userService.CreateAsycn(userCreateDto);



