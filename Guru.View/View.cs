using Guru.DAL.Repositories;
using Guru.Domain.Enums.Roles;
using Guru.Service.DTOs.UserDto;
using Guru.Service.Services;
using Guru.View.Admins;
using Guru.View.Clients;
using Guru.View.Freelancers;
using Guru.View.ProjectManager;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace Guru.View;

public class View
{

    ClientPanel clientPanel = new ClientPanel();

    public void Output()
    {
        Console.WriteLine("------Welcome Guru-----");
        Console.WriteLine("1.Sign in");
        Console.WriteLine("2.Sign up");
        int choose=int.Parse(Console.ReadLine());

        switch (choose)
        {
            case 1:
                SignIn(); break;
            case 2:
                SignUp(); break;
            default: Output(); break;
        }

    }
    public async void SignIn()
    {
        UnitOfWork unitOfWork = new UnitOfWork();
         
        Console.Write("Email: ");
        string email=Console.ReadLine();
        Console.Write("Password: ");
        string password=Console.ReadLine();

        var result= await unitOfWork.UserRepository.SelectByEmail(email);
        if(result is null )
        {
            Console.Clear();
            Console.WriteLine("This email not found");
            Output();
        }
        else if (!result.Password.Equals(password))
        {
            Console.Clear();
            Console.WriteLine("Password error");
            Output();
        }

        switch (result.Role)
        {
            case Domain.Enums.Roles.Role.Admin: AdminPanel.Output(result); break;

            case Domain.Enums.Roles.Role.ProjectManager: ProjectManagerPanel.Output(result); break;

            case Domain.Enums.Roles.Role.Freelancer: FreelancesPanel.Output(result); break;

            case Domain.Enums.Roles.Role.Client: clientPanel.Output(result); break;
        }
    }

    public async void SignUp()
    {
        UnitOfWork unitOfWork=new UnitOfWork();

        Console.Write("FirstName: ");
        string firstname=Console.ReadLine();

        Console.Write("LastName: ");
        string lastname = Console.ReadLine();

        Console.Write("NickName: ");
        string nickname = Console.ReadLine();

        Console.Write("Phone: ");
        string phone = Console.ReadLine();

        Console.Write("Bio: ");
        string bio = Console.ReadLine();

        Console.WriteLine("Role: ");
        Console.WriteLine("     1.Freelance ");
        Console.WriteLine("     2.Clien ");
        Console.WriteLine("     3.Projectmanager ");


        int choose = int.Parse(Console.ReadLine());
        Role role=0;
        switch (choose)
        {
            case 1: role= Role.Freelancer; break;
            case 2: role= Role.Client; break;
            case 3: role= Role.Admin; break;
        }

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("password: ");
        string password = Console.ReadLine();


        UserCreateDto userCreateDto = new UserCreateDto()
        {
            FirstName=firstname,
            LastName=lastname,
            NickName=nickname,
            Phone=phone,
            Role=role,
            Bio=bio,
            Email=email,
            Password=password
        };

       UserService userService = new UserService();
       var result= await userService.CreateAsycn(userCreateDto);

        Console.WriteLine(result.Message);
        Output();

    }


}
