using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.BusinessLogic.Models;
using UserManagement.DataAccess.Models;

namespace UserManagement.BusinessLogic.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Role, RoleModel>().ReverseMap();

        }
    }
}
