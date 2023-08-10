using AutoMapper;   
using Guru.DAL.Repositories;
using Guru.Service.DTOs.MissionDto;
using Guru.Service.Helpers;
using Guru.Service.Interfaces;
using Guru.Service.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Guru.Service.Services;

public class TaskService : IMissonService
{
    private readonly UnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public TaskService()
    {
        unitOfWork = new UnitOfWork();
        this.mapper = new Mapper(new MapperConfiguration(c => c.AddProfile<AutoMapping>()));
    }

    public async Task<Response<MissionResultDto>> CreateAsycn(MissionCreateDto dto)
    {
        var exist = await unitOfWork.TaskRepository.GetMissionAsync(dto.TaskName);
        if(exist is not null)
        {
            return new Response<MissionResultDto>
            {
                StatusCode = 403,
                Message = "This task already exist",
            };
        }

        var data= mapper.Map<Mission>(dto);
        await unitOfWork.TaskRepository.CreateAsync(data);
        await unitOfWork.SaveAsync();
        var result = mapper.Map<MissionResultDto>(data);

        return new Response<MissionResultDto>
        {
            StatusCode = 200,
            Message = "Succes",
            Data = result
        };
    }

    public async Task<Response<MissionResultDto>> UpdateAsycn(MissionUpdateDto dto)
    {
        var exist = await unitOfWork.TaskRepository.SelectByIdAsync(dto.Id);
        if(exist is null)
        {
            return new Response<MissionResultDto>
            {
                StatusCode = 404,
                Message = "Not found"
            };
        }
        var result = mapper.Map(dto, exist);
        unitOfWork.TaskRepository.Update(result);
        await unitOfWork.SaveAsync();

        var data= mapper.Map<MissionResultDto>(result);

        return new Response<MissionResultDto>
        {
            StatusCode = 200,
            Message = "Succes",
            Data = data
        };
    }
    public async Task<Response<bool>> DeleteAsycn(long id)
    {
        var exist= await unitOfWork.TaskRepository.SelectByIdAsync(id);
        if(exist is null)
        {
            return new Response<bool>
            {
                StatusCode = 404,
                Message = "This task not found"
            };
        }

        unitOfWork.TaskRepository.Delete(exist);
        await unitOfWork.SaveAsync();

        return new Response<bool>
        {
            StatusCode = 200,
            Message = "Succes",
            Data = true
        };
    }

    public async Task<Response<IEnumerable<MissionResultDto>>> GetAll()
    {
        var exist = await unitOfWork.TaskRepository.SelectAll().ToListAsync();

        var result= mapper.Map<IEnumerable<MissionResultDto>>(exist);

        return new Response<IEnumerable<MissionResultDto>>
        {
            StatusCode = 200,
            Message = "Succes",
            Data = result
        };
    }

    public async Task<Response<MissionResultDto>> SearchById(long id)
    {
        var exist = await unitOfWork.TaskRepository.SelectByIdAsync(id);
        if(exist is null)
        {
            return new Response<MissionResultDto>
            {
                StatusCode = 200,
                Message = "This task not found"
            };
        }

        var result=mapper.Map<MissionResultDto>(exist);

        return new Response<MissionResultDto>
        {
            StatusCode = 200,
            Message = "Succes",
            Data = result
        };
    }

}
