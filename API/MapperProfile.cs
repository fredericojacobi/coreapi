using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using FirstApp.Controllers;

namespace FirstApp
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Branch, BranchDTO>().ReverseMap();
         
            CreateMap<Company, CompanyDTO>().ReverseMap();
            
            CreateMap<Company, CompanyDTO>().ReverseMap();
            
            CreateMap<EletronicPointHistoryDTO, EletronicPointHistory>().ReverseMap();
            // CreateMap<EletronicPointHistory, EletronicPointHistoryDTO>();
            
            CreateMap<Event, EventDTO>().ReverseMap();
            
            CreateMap<Location, LocationDTO>().ReverseMap();
            
            CreateMap<Point, PointDTO>().ReverseMap();
            
            CreateMap<Reminder, ReminderDTO>().ReverseMap();
            // CreateMap<ReminderDTO, Reminder>();
            
            CreateMap<User, UserDTO>().ReverseMap();
            
            CreateMap<IBGE, Location>().ReverseMap();
            
        }
    }
}