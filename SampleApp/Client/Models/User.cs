using SampleApp.Client.Enums;

namespace SampleApp.Client.Models;

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public UserType UserType { get; set; }

    public DateTime Created { get; set; }
    public DateTime? LastModified { get; set; }
}

