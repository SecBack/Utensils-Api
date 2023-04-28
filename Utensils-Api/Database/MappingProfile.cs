using AutoMapper;
using Shared.Dto.Models;
using Utensils_Api.Database.Models;

namespace Utensils_Api.Database
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventDto>().ForMember(dest => 
                dest.Users, opt => opt.MapFrom(src => src.Users.Select(u => u.Id)));

            CreateMap<Payment, PaymentDto>();

            CreateMap<Group, GroupDto>().ForMember(dest =>
                dest.Users, opt => opt.MapFrom(src => src.Users.Select(g => g.Id))).ForMember(dest => 
                dest.Events, opt => opt.MapFrom(src => src.Events.Select(e => e.Id)));

            CreateMap<User, UserDto>().ForMember(dest =>
                dest.Groups, opt => opt.MapFrom(src => src.Groups.Select(g => g.Id))).ForMember(dest => 
                dest.Events, opt => opt.MapFrom(src => src.Events.Select(e => e.Id)));

        }
    }
}
