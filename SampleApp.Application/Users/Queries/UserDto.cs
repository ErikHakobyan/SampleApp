using AutoMapper;
using SampleApp.Application.Common.Mappings;
using SampleApp.Domain.Entities;
using SampleApp.Domain.Enums;

namespace SampleApp.Application.Users.Queries;

public class UserDto : IMapFrom<User>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int UserType { get; set; }

    public DateTime Created { get; set; }
    public DateTime? LastModified { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, UserDto>()
            .ForMember(d => d.UserType, opt => opt.MapFrom(s => (int)s.UserType));
    }
}

