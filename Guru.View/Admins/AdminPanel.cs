using Guru.Domain.Entities.Projects;
using Guru.Domain.Entities.Users;
using Guru.Service.Services;

namespace Guru.View.Admins;

public class AdminPanel
{
    ProjectService projectService =new ProjectService();
    UserService userService =new UserService();

    public  void Output(User user)
    {
        Console.WriteLine("-----Welcome Admin-----");
        Console.WriteLine("1.Projects");
        Console.WriteLine("2.Clients");
        Console.WriteLine("3.Freelances");
        Console.WriteLine("4.Project Manager");

        int choose=int.Parse(Console.ReadLine());

        switch (choose)
        {
            case 1: Projects(); break;
            case 2: Clients(); break;
            case 3: Freelance(); break;
            case 4: ProjectMeneger(); break;
        }
    }

    public  void Projects()
    {
        var exist=projectService.GetAll().Result.Data.ToList();
        int count = 0;
        foreach (var item in exist)
        {
            Console.WriteLine($"{++count}-Project");
            Console.WriteLine("Project Name: "+item.ProjectName);
            Console.WriteLine("Deadline: "+projectService.TimeDifference(item));
            Console.WriteLine("Client Name "+userService.SearchById(item.Id).Result.Data.FirstName);
            Console.WriteLine("Client Contact"+userService.SearchById(item.Id).Result.Data.Phone);
        }
    }

    public void Clients() 
    {
        var users= userService.GetByRole(Domain.Enums.Roles.Role.Client).Result.Data.ToList();
        foreach(var user in users)
        {
            Console.WriteLine("FirstName: "+user.FirstName); 
            Console.WriteLine("LastName: "+user.LastName);
            Console.WriteLine("Phone: "+user.Phone);
            Console.WriteLine("Phone: "+user.Email);
        }
    }

    public void Freelance()
    {
        var users = userService.GetByRole(Domain.Enums.Roles.Role.Freelancer).Result.Data.ToList();
        foreach (var user in users)
        {
            Console.WriteLine("FirstName: " + user.FirstName);
            Console.WriteLine("LastName: " + user.LastName);
            Console.WriteLine("Phone: " + user.Email);
            Console.WriteLine("Bio: " + user.Bio);
        }
    }

    public void ProjectMeneger()
    {
        var users = userService.GetByRole(Domain.Enums.Roles.Role.ProjectManager).Result.Data.ToList();
        foreach (var user in users)
        {
            Console.WriteLine("FirstName: " + user.FirstName);
            Console.WriteLine("LastName: " + user.LastName);
            Console.WriteLine("Phone: " + user.Email);
            Console.WriteLine("Bio: " + user.Bio);
        }
    }
}
