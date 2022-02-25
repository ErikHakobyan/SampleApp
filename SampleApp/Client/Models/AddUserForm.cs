using SampleApp.Client.Enums;
using System.ComponentModel.DataAnnotations;

namespace SampleApp.Client.Models;

public class AddUserForm
{
    [Required]
    [MaxLength(40)]
    public string? Name { get; set; }
    public UserType UserType { get; set; }
}

