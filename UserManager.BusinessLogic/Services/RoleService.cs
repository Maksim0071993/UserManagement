using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserManagement.BusinessLogic.Interface;
using UserManagement.BusinessLogic.Mapper;
using UserManagement.BusinessLogic.Models;
using UserManagement.DataAccess.Interface;
using UserManagement.DataAccess.Models;

namespace UserManagement.BusinessLogic.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            var config = new AutoMapper.MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            var mapper = config.CreateMapper();
            _mapper = mapper;
        }
        public void AddRole(RoleModel model)
        {
            var role = _mapper.Map<Role>(model);
            _unitOfWork.Role.Add(role);
            _unitOfWork.Save();
        }

        public List<RoleModel> GetAllRoles()
        {
            var roles = _unitOfWork.Role.GetAll();
            var result = roles.Select(p => _mapper.Map<RoleModel>(p)).ToList();
            return result;
        }

        public RoleModel GetRoleById(int id)
        {
            var role = _unitOfWork.User.GetById(id);
            var roleModel = _mapper.Map<RoleModel>(role);
            return roleModel;
        }
        public RoleModel GetRoleByName(string name)
        {
            var role = _unitOfWork.Role.GetRoleByName(name);
            var roleModel = _mapper.Map<RoleModel>(role);
            return roleModel;
        }

        public List<RoleModel> GetRolesByUser(UserModel userModel)
        {
            var user = _mapper.Map<User>(userModel);
            var roles = _unitOfWork.User.GetRolesByUser(user).ToList();
            var rolesModel = _mapper.Map<List<RoleModel>>(roles);
            return rolesModel;
        }
    }
}
