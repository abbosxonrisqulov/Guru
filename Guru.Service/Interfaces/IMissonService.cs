using Guru.Service.DTOs.MissionDto;
using Guru.Service.DTOs.ProjectDto;
using Guru.Service.Helpers;

namespace Guru.Service.Interfaces;

public interface IMissonService
{
    Task<Response<MissionResultDto>> CreateAsycn(MissionCreateDto dto);
    Task<Response<MissionResultDto>> UpdateAsycn(MissionUpdateDto dto);
    Task<Response<bool>> DeleteAsycn(long id);
    Task<Response<MissionResultDto>> SearchById(long id);
    Task<Response<IEnumerable<MissionResultDto>>> GetAll();
}
