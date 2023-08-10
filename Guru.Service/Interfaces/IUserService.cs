using Guru.Service.DTOs.UserDto;
using Guru.Service.Helpers;

namespace Guru.Service.Interfaces;

public interface IUserService
{
    Task<Response<UserResultDto>> CreateAsycn(UserCreateDto dto);
    Task<Response<UserResultDto>> UpdateAsycn(UserUpdateDto dto);
    Task<Response<bool>> DeleteAsycn(long id);
    Task<Response<UserResultDto>> SearchById(long id);
    Task<Response<IEnumerable<UserResultDto>>> GetAll();
}

