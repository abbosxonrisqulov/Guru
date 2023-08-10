using AutoMapper;
using Guru.Domain.Entities.Messages;
using Guru.Domain.Entities.Projects;
using Guru.Domain.Entities.Users;
using Guru.Service.DTOs.MessageDto;
using Guru.Service.DTOs.MissionDto;
using Guru.Service.DTOs.ProjectDto;
using Guru.Service.DTOs.UserDto;

namespace Guru.Service.Mappers;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<UserCreateDto, User>().ReverseMap();
        CreateMap<UserUpdateDto, User>().ReverseMap();
        CreateMap<UserResultDto, User>().ReverseMap();


        CreateMap<ProjectResultDto, Project>().ReverseMap();
        CreateMap<ProjectUpdateDto, Project>().ReverseMap();
        CreateMap<ProjectCreateDto, Project>().ReverseMap();

        CreateMap<Mission, MissionResultDto>().ReverseMap();
        CreateMap<Mission, MissionUpdateDto>().ReverseMap();
        CreateMap<Mission, MissionCreateDto>().ReverseMap();

        CreateMap<Message,MessageCreateDto>().ReverseMap();
        CreateMap<Message, MessageResultDto>().ReverseMap();
        CreateMap<Message, MessageUpdateDto>().ReverseMap();
    }
}
