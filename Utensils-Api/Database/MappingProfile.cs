using AutoMapper;
using Newtonsoft.Json;
using Shared.Dto.Models;
using Utensils_Api.Database.Models;

namespace Utensils_Api.Database
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User to UserDto mapping map username from identity user to userdto
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.OwedPayments, opt => opt.MapFrom(src => src.OwedPayments))
                .ForMember(dest => dest.ReceivingPayments, opt => opt.MapFrom(src => src.ReceivingPayments))
                .ForMember(dest => dest.Groups, opt => opt.MapFrom(src => src.Groups))
                .ForMember(dest => dest.Events, opt => opt.MapFrom(src => src.Events))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));

            // Group to GroupDto mapping
            CreateMap<Group, GroupDto>()
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users))
                .ForMember(dest => dest.Events, opt => opt.MapFrom(src => src.Events));
            CreateMap<GroupDto, Group>()
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users))
                .ForMember(dest => dest.Events, opt => opt.MapFrom(src => src.Events));

            // Payment to PaymentDto mapping
            CreateMap<Payment, PaymentDto>();

            // Event to EventDto mapping
            CreateMap<Event, EventDto>();

            //CreateMap<Event, EventDto>().ForMember(dest => 
            //    dest.Users, opt => opt.MapFrom(src => src.Users.Select(u => u.Id)));

            //CreateMap<Payment, PaymentDto>();

            //CreateMap<Group, GroupDto>();
            //CreateMap<GroupDto, Group>();
            //CreateMap<Group, GroupDto>().ForMember(dest =>
            //    dest.Users, opt => opt.MapFrom(src => src.Users.Select(g => g.Id))).ForMember(dest => 
            //    dest.Events, opt => opt.MapFrom(src => src.Events.Select(e => e.Id)));

            //CreateMap<User, UserDto>().ForMember(dest =>
            //    dest.Groups, opt => opt.MapFrom(src => src.Groups.Select(g => g.Id))).ForMember(dest => 
            //    dest.Events, opt => opt.MapFrom(src => src.Events.Select(e => e.Id)));
        }
    }
}
