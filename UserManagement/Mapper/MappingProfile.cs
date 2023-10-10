using AutoMapper;
using UserManagement.BusinessLogic.Models;
using UserManagement.DataAccess.Models;
using UserManagement.Models;

namespace UserManagement.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap< UserModel, UserViewModel>().ReverseMap();
            CreateMap< RoleModel, RoleViewModel>().ReverseMap();

        }
    }
}
