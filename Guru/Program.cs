
using Guru.Domain.Enums.Roles;
using Guru.Service.DTOs.UserDto;
using Guru.Service.Services;

UserUpdateDto userCreateDto = new UserUpdateDto()
{
    Id = 2,
    FirstName = "Abbosxon",
    LastName = "Risqulov",
    Email = "abbosnewz1@gmail.com",
    Password = "1234",
    NickName = "NewBillionaire",
    Bio = "test",
    Phone = "+9989116651111",
    Role = Role.Client,
};

UserService userService = new UserService();
var result = await userService.GetAll();

result.Data.ToList().ForEach(x=>Console.WriteLine(x.Phone));

