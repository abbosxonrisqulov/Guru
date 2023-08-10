using Guru.Domain.Entities.Messages;
using Guru.Domain.Entities.Projects;
using Guru.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Guru.DAL.DbContexts;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string stringConnection = "Host=localhost; Port=5432; User Id=postgres; Database=NebulaDb; Password=1234;";
        optionsBuilder.UseNpgsql(stringConnection);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Message> Messages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>()
            .HasOne(c => c.User)
            .WithMany()
            .HasForeignKey(c => c.ClientId);

        modelBuilder.Entity<Message>()
            .HasOne(m => m.User)
            .WithMany()
            .HasForeignKey(m => m.SenderId);

        modelBuilder.Entity<Message>()
            .HasOne(m => m.User)
            .WithMany()
            .HasForeignKey(m => m.ReceiverId);

        modelBuilder.Entity<Message>()
            .HasOne(m => m.Project)
            .WithMany()
            .HasForeignKey(m => m.ProjectId);

        modelBuilder.Entity<Task>()
            .HasOne(t => t.User)
            .WithMany()
            .HasForeignKey(t => t.AssignedTo);

        modelBuilder.Entity<Task>()
           .HasOne(t => t.Project)
           .WithMany()
           .HasForeignKey(t => t.ProjectId);
    }
}
