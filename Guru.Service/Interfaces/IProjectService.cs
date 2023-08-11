using Guru.Domain.Entities.Projects;
using Guru.Service.DTOs.ProjectDto;
using Guru.Service.DTOs.UserDto;
using Guru.Service.Helpers;

namespace Guru.Service.Interfaces;

public interface IProjectService
{
    Task<Response<ProjectResultDto>> CreateAsycn(ProjectCreateDto dto);
    Task<Response<ProjectResultDto>> UpdateAsycn(ProjectUpdateDto dto);
    Task<Response<bool>> DeleteAsycn(long id);
    Task<Response<ProjectResultDto>> SearchById(long id);
    Task<Response<IEnumerable<ProjectResultDto>>> GetAll();
    Task<Response<IEnumerable<ProjectResultDto>>> GetByClientId(long id);
}
