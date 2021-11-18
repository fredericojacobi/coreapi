using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace FirstApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Reminder, ReminderDTO>();
            CreateMap<ReminderDTO, Reminder>();
        }
    }
}