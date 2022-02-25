namespace SampleApp.Domain.Entities;

public class User : AuditableEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public UserType UserType { get; set; }
}

