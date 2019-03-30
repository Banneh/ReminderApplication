using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts.Dto;
using Reminder.DataAccessLayer.DataModels;

namespace Reminder.Api.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<ToDo, ToDoDto>();
            CreateMap<ToDoDto, ToDo>();

            CreateMap<Group, GroupDto>();
            CreateMap<GroupDto, Group>();
        }
    }
}
