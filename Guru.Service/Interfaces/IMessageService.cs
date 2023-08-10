using Guru.Service.DTOs.MessageDto;
using Guru.Service.Helpers;

namespace Guru.Service.Interfaces;

public interface IMessageService
{
    Task<Response<MessageResultDto>> CreateAsync(MessageCreateDto dto);
    Task<Response<MessageResultDto>> UpdateAsync(MessageUpdateDto dto);
    Task<Response<bool>> DeletAsync(long id);
    Task<Response<MessageResultDto>> SearchByIdAsync(long id );
    Task<Response<IEnumerable<MessageResultDto>>> GetAllAsync();

}
