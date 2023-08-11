using AutoMapper;
using Guru.DAL.Repositories;
using Guru.Domain.Entities.Projects;
using Guru.Service.DTOs.ProjectDto;
using Guru.Service.Helpers;
using Guru.Service.Interfaces;
using Guru.Service.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Guru.Service.Services;

public class ProjectService : IProjectService
{
    private readonly UnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public ProjectService()
    {
        unitOfWork = new UnitOfWork();
        this.mapper = new Mapper(new MapperConfiguration(c => c.AddProfile<AutoMapping>()));
    }


    public async Task<Response<ProjectResultDto>> CreateAsycn(ProjectCreateDto dto)
    {
        var exist = await unitOfWork.ProjectRepository.GetByName(dto.ProjectName);

        if (exist is not null)
        {
            return new Response<ProjectResultDto>()
            {
                StatusCode = 403,
                Message = "This project ongoing"
            };
        }
        var data = mapper.Map<Project>(dto);
        await unitOfWork.ProjectRepository.CreateAsync(data);
        await unitOfWork.SaveAsync();

        var result=mapper.Map<ProjectResultDto>(data);

        return new Response<ProjectResultDto>
        {
            StatusCode = 200,
            Message = "Succes",
            Data = result
        };
    }
    public async Task<Response<ProjectResultDto>> UpdateAsycn(ProjectUpdateDto dto)
    {
        var exist = await unitOfWork.ProjectRepository.SelectByIdAsync(dto.Id);
        if (exist is  null)
        {
            return new Response<ProjectResultDto>()
            {
                StatusCode = 403,
                Message = "This project not found"
            };
        }

        var data = mapper.Map(dto, exist);

        unitOfWork.ProjectRepository.Update(exist);
        await unitOfWork.SaveAsync();

        var result= mapper.Map<ProjectResultDto>(data);

        return new Response<ProjectResultDto>
        {
            StatusCode = 200,
            Message = "Succes",
            Data = result
        };
    }
    public async Task<Response<bool>> DeleteAsycn(long id)
    {
        var exist = await unitOfWork.ProjectRepository.SelectByIdAsync(id);
        if(exist is null)
        {
            return new Response<bool>()
            {
                StatusCode = 403,
                Message = "This project not found"
            };
        }

        unitOfWork.ProjectRepository.Delete(exist);
        await unitOfWork.SaveAsync();

        return new Response<bool>()
        {
            StatusCode = 403,
            Message = "Succes",
            Data=true
        };
    }

    public async Task<Response<IEnumerable<ProjectResultDto>>> GetAll()
    {
        var exist = await unitOfWork.ProjectRepository.SelectAll().ToListAsync();

        var result= mapper.Map<IEnumerable<ProjectResultDto>>(exist);

        return new Response<IEnumerable<ProjectResultDto>>
        {
            StatusCode = 200,
            Message = "Succes",
            Data = result
        };
    }

    public async Task<Response<ProjectResultDto>> SearchById(long id)
    {
        var exist = await unitOfWork.ProjectRepository.SelectByIdAsync(id);
        if (exist is null)
        {
            return new Response<ProjectResultDto>
            {
                StatusCode = 404,
                Message = "This Project not fount",
                Data = null
            };
        }

        var result= mapper.Map<ProjectResultDto>(exist);

        return new Response<ProjectResultDto>
        {
            StatusCode = 200,
            Message = "Succes",
            Data = result
        };
    }

    public async Task<Response<IEnumerable<ProjectResultDto>>> GetByClientId(long id)
    {
        var result= GetAll().Result.Data.Where(x => x.ClientId == id);

        var data = mapper.Map<IEnumerable<ProjectResultDto>>(result);

        return new Response<IEnumerable<ProjectResultDto>> { StatusCode = 200, Message = "Succes", Data = data };
    }

}
