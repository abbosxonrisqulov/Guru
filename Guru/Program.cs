
using Guru.Domain.Enums.ProjectStatuses;
using Guru.Domain.Enums.Roles;
using Guru.Service.DTOs.MessageDto;
using Guru.Service.DTOs.MissionDto;
using Guru.Service.DTOs.ProjectDto;
using Guru.Service.DTOs.UserDto;
using Guru.Service.Services;


MessageService messageService = new MessageService();


MessageUpdateDto messageCreateDto = new MessageUpdateDto()
{
    Id=2,
    SenderId = 2,
    ReceiverId = 1,
    MessadeStatus = Guru.Domain.Enums.MessageStatuses.MessageStatus.Send,
    MessageText = "",
    TimeStamp = DateTime.UtcNow,
    ProjectId = 1,
};
var resuilt=await messageService.UpdateAsync(messageCreateDto);

Console.WriteLine(resuilt.Data.MessageText);