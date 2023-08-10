namespace Guru.Domain.Commons;

public abstract class  Auditable
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set;}
}
