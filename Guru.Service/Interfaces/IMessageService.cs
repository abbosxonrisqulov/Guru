using Guru.Service.DTOs.MessageDto;
using Guru.Service.Helpers;

namespace Guru.Service.Interfaces;

public interface IMessageService
{
    Task<Response<MessageResultDto>> CreateAsync(MessageCreateDto dto);
    Task<Response<MessageResultDto>> UpdateAsync(MessageCreateDto dto);
    Task<Response<bool>> dDeletAsync(long id);
    Task<Response<MessageResultDto>> SearchByIdAsync(long id );
    Task<Response<IEnumerable<MessageResultDto>>> GetAllAsync();

}
