using Guru.Domain.Entities.Users;
using Guru.Domain.Enums.Roles;
using Guru.Service.DTOs.ProjectDto;
using Guru.Service.DTOs.UserDto;
using Guru.Service.Mappers;
using Guru.Service.Services;

namespace Guru.View.Clients;

public class ClientPanel
{
    private readonly AutoMapping autoMapping = new AutoMapping();
    UserService userService = new UserService();
    ProjectService projectService = new ProjectService();
    public long  UserId { get; set; }
    public Role Role { get; set; }
    public  void Output(User user)
    {
        UserId = user.Id;
        Role = user.Role;
        Console.WriteLine($"---Welcome {user.FirstName}---");
        Console.WriteLine("1.My Projects");
        Console.WriteLine("2.Create Project");
        Console.WriteLine("3.Update My Information");
        Console.WriteLine("4.Info");

        int choose =int.Parse(Console.ReadLine());

        switch (choose)
        {
            case 1: MyProject(); break;
            case 2: CreateProject(); break;
            case 3: Update(); break;
            case 4: Information(); break;

        }
    }

    public async void MyProject()
    {
        var result= projectService.GetByClientId(UserId).Result.Data.ToList();

        foreach(var item in result)
        {
            Console.WriteLine(item.ProjectName);
        }
       
    }
    public async void CreateProject()
    {
        Console.Write("Project Name :");
        string projectname = Console.ReadLine();

        Console.Write("Startdate :");
        DateTime start = DateTimeOffset.Parse(DateTime.Parse(Console.ReadLine()).ToString()).UtcDateTime;

        Console.Write("Enddate :");
        DateTime end = DateTimeOffset.Parse(DateTime.Parse(Console.ReadLine()).ToString()).UtcDateTime;

        Console.Write("Description :");
        string description= Console.ReadLine();

        ProjectCreateDto projectCreateDto = new ProjectCreateDto()
        {
            ProjectName=projectname,
            ClientId=UserId,
            StartDate=start,
            EndDate= end,
            Description=description,
            Status=Domain.Enums.ProjectStatuses.ProjectStatus.Ongoing
        };

        ProjectService projectService = new ProjectService();
        var result = await projectService.CreateAsycn(projectCreateDto);
        Console.WriteLine(result.Message);


    }
    public async void Update()
    {
        Console.Write("FirstName: ");
        string firstname = Console.ReadLine();

        Console.Write("LastName: ");
        string lastname = Console.ReadLine();

        Console.Write("NickName: ");
        string nickname = Console.ReadLine();

        Console.Write("Phone: ");
        string phone = Console.ReadLine();

        Console.Write("Bio: ");
        string bio = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("password: ");
        string password = Console.ReadLine();

        UserUpdateDto userUpdateDto = new UserUpdateDto()
        {
            Id=UserId,
            FirstName=firstname,
            LastName=lastname,
            NickName=nickname,
            Phone=phone,
            Bio=bio,
            Role=this.Role,
            Email=email,
            Password=password
        };

        var result= await userService.UpdateAsycn(userUpdateDto);

        Console.Clear();
        Console.WriteLine(result.Message);
        
    }
    public async void Information()
    {
        var result = await userService.SearchById(UserId);

        Console.WriteLine("FirstName: " + result.Data.FirstName);
        Console.WriteLine("LastName: " + result.Data.LastName);
        Console.WriteLine("NickName: " + result.Data.NickName);
        Console.WriteLine("Phone: " + result.Data.Phone);
        Console.WriteLine("Bio: " + result.Data.Bio);
        Console.WriteLine("Email: " + result.Data.Email);
        Console.WriteLine("Password: " + result.Data.Password);

    }
}
