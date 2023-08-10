using AutoMapper;
using Guru.DAL.IRepositories;
using Guru.DAL.Repositories;
using Guru.Domain.Entities.Users;
using Guru.Service.DTOs.UserDto;
using Guru.Service.Helpers;
using Guru.Service.Interfaces;
using Guru.Service.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Guru.Service.Services;

public class UserService : IUserService
{
    private readonly UnitOfWork unitOfWork;
    private readonly IMapper mapper;


    public UserService()
    {
        unitOfWork = new UnitOfWork();
        this.mapper = new Mapper(new MapperConfiguration(c => c.AddProfile<AutoMapping>()));
    }
    public async Task<Response<UserResultDto>> CreateAsycn(UserCreateDto dto)
    {
        var exist= await unitOfWork.UserRepository.SelectByPhone(dto.Phone);
        if(exist is not null)
        {
            return new Response<UserResultDto>()
            {
                StatusCode = 403,
                Message = "this user already exist",
            };
        }
        User mapUser = mapper.Map<User>(dto);

        await unitOfWork.UserRepository.CreateAsync(mapUser);
        await unitOfWork.SaveAsync();

        var res = mapper.Map<UserResultDto>(mapUser);

        return new Response<UserResultDto>
        {
            StatusCode = 200,
            Message = "Succes",
            Data = res
        };
    }

    public async Task<Response<bool>> DeleteAsycn(long id)
    {
        var exist= await unitOfWork.UserRepository.SelectByIdAsync(id);
        if(exist is null)
        {
            return new Response<bool>
            {
                StatusCode = 404,
                Message = "this user not found"
            };
        }

        unitOfWork.UserRepository.Delete(exist);
        await unitOfWork.SaveAsync();

        return new Response<bool>
        {
            StatusCode = 200,
            Message = "Succes",
            Data = true
        };
    }



    public async Task<Response<IEnumerable<UserResultDto>>> GetAll()
    {
        var exist =await unitOfWork.UserRepository.SelectAll().ToListAsync();


        var result = this.mapper.Map<IEnumerable<UserResultDto>>(exist);
        return new Response<IEnumerable<UserResultDto>>
        {
            StatusCode = 200,
            Message = "Succes",
            Data = result
        };

    }

    public async Task<Response<UserResultDto>> SearchById(long id)
    {
        var exist = await unitOfWork.UserRepository.SelectByIdAsync(id);

        if (exist is null)
        {
            return new Response<UserResultDto>()
            {
                StatusCode = 403,
                Message = "this user not found",
            };
        }
        var result= mapper.Map<UserResultDto>(exist);

        return new Response<UserResultDto>
        {
            StatusCode = 200,
            Message = "Succes",
            Data = result
        };
    }

    public async Task<Response<UserResultDto>> UpdateAsycn(UserUpdateDto dto)
    {
        var exist = await unitOfWork.UserRepository.SelectByIdAsync(dto.Id);
        if (exist is null)
        {
            return new Response<UserResultDto>
            {
                StatusCode = 404,
                Message = "THis user not found"
            };
        }

        var data = mapper.Map(dto, exist);
        unitOfWork.UserRepository.Update(data);
        await unitOfWork.SaveAsync();

        var result = mapper.Map<UserResultDto>(data);

        return new Response<UserResultDto>
        {
            StatusCode = 200,
            Message = "Succes",
            Data = result
        };
    }
}
