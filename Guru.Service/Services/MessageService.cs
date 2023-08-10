using AutoMapper;
using Guru.DAL.IRepositories;
using Guru.DAL.Repositories;
using Guru.Domain.Entities.Messages;
using Guru.Service.DTOs.MessageDto;
using Guru.Service.Helpers;
using Guru.Service.Interfaces;
using Guru.Service.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Guru.Service.Services;

public class MessageService : IMessageService
{
    private readonly UnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public MessageService()
    {
        unitOfWork = new UnitOfWork();
        this.mapper = new Mapper(new MapperConfiguration(c => c.AddProfile<AutoMapping>()));
    }
    public async Task<Response<MessageResultDto>> CreateAsync(MessageCreateDto dto)
    {
        var data= mapper.Map<Message>(dto);

        await unitOfWork.MessageRepositoy.CreateAsync(data);
        await unitOfWork.SaveAsync();
        var result = mapper.Map<MessageResultDto>(data);
        return new Response<MessageResultDto>
        {
            StatusCode = 200,
            Message = "Succes",
            Data = result
        };
    }

    public async Task<Response<bool>> DeletAsync(long id)
    {
        var exist = await unitOfWork.MessageRepositoy.SelectByIdAsync(id);

        if (exist is null)
        {
            return new Response<bool>
            {
                StatusCode = 404,
                Message = "not found"
            };
        }

        unitOfWork.MessageRepositoy.Delete(exist);
        await unitOfWork.SaveAsync();

        return new Response<bool>
        {
            StatusCode = 200,
            Message = "Succes",
            Data = true
        };
    }

    public async Task<Response<IEnumerable<MessageResultDto>>> GetAllAsync()
    {
        var exist = await unitOfWork.MessageRepositoy.SelectAll().ToListAsync();

        var result=mapper.Map<IEnumerable<MessageResultDto>>(exist);

        return new Response<IEnumerable<MessageResultDto>>
        {
            StatusCode = 200,
            Message = "Succes",
            Data = result
        };
    }

    public async Task<Response<MessageResultDto>> SearchByIdAsync(long id)
    {
        var exist = await unitOfWork.MessageRepositoy.SelectByIdAsync(id);
        if(exist is null)
        {
            return new Response<MessageResultDto>
            {
                StatusCode = 404,
                Message = "Not found",
                Data = null
            };
        }
        var result= mapper.Map<MessageResultDto>(exist);

        return new Response<MessageResultDto>
        {
            StatusCode = 200,
            Message = "Succes",
            Data = result
        };
    }

    public async Task<Response<MessageResultDto>> UpdateAsync(MessageUpdateDto dto)
    {
        var exist = await unitOfWork.MessageRepositoy.SelectByIdAsync(dto.Id);
        if (exist is null)
        {
            return new Response<MessageResultDto>
            {
                StatusCode = 404,
                Message = "Not found"
            };
        }
        var data = mapper.Map(dto, exist);
        unitOfWork.MessageRepositoy.Update(data);
        await unitOfWork.SaveAsync();

        var result=mapper.Map<MessageResultDto>(data);
        return new Response<MessageResultDto>
        {
            StatusCode = 200,
            Message = "Succes",
            Data = result
        };
    }
}
