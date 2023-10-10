using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserManagement.BusinessLogic.Filters;
using UserManagement.BusinessLogic.Interface;
using UserManagement.BusinessLogic.Mapper;
using UserManagement.BusinessLogic.Models;
using UserManagement.DataAccess.Interface;
using UserManagement.DataAccess.Models;

namespace UserManagement.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            var config = new AutoMapper.MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            var mapper = config.CreateMapper();
            _mapper = mapper;
        }
        public void AddUser(UserModel model)
        {
            var user = _mapper.Map<User>(model);
            _unitOfWork.User.Add(user);
            _unitOfWork.Save();
        }
        public void AddRoleForUser(RoleModel model, UserModel userModel)
        {
            var role = _mapper.Map<Role>(model);
            var user = _mapper.Map<User>(userModel);
            _unitOfWork.User.AddRoleForUser(role, user);
            _unitOfWork.Save();
        }

        public List<UserModel> GetAllUsers(UsersFilter filter)
        {
            var users = _unitOfWork.User.GetAll();
            if (filter.UserName != null)
            {
                users = users.Where(p => p.Name == filter.UserName);
            }
            if(filter.Age != 0)
            {
                users = users.Where(p => p.Age == filter.Age);
            }
            if (filter.Email != null)
            {
                users = users.Where(p => p.Name.Contains(filter.Email));
            }
            var result = users.Select(p => _mapper.Map<UserModel>(p)).ToList();
            return result;
        }
        public UserModel GetUsersByEmail(string email)
        {
            var user = _unitOfWork.User.GetByEmail(email);           
            var result = _mapper.Map<UserModel>(user);

            return result;
        }

        public UserModel GetUserById(int id)
        {
            var user = _unitOfWork.User.GetById(id);
            var userModel = _mapper.Map<UserModel>(user);
            return userModel;
        }

        public List<RoleModel> GetRolesByUser(UserModel userModel)
        {
            var user = _mapper.Map<User>(userModel);
            var roles = _mapper.Map<List<RoleModel>>(_unitOfWork.User.GetRolesByUser(user));

            return roles;
        }

        public void DeleteUser(int id)
        {
            _unitOfWork.User.DeleteUser(id);
        }
        public void UpdateUser(UserModel userModel)
        {
            var user = _mapper.Map<User>(userModel);
            _unitOfWork.User.UpdateUser(user);
        }
    }
}
