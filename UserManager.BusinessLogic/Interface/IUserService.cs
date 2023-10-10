using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.BusinessLogic.Filters;
using UserManagement.BusinessLogic.Models;
using UserManagement.DataAccess.Models;

namespace UserManagement.BusinessLogic.Interface
{
    public interface IUserService
    {
        void AddUser(UserModel model);
        UserModel GetUserById(int id);
        List<UserModel> GetAllUsers(UsersFilter filter);
        void DeleteUser(int id);
        void UpdateUser(UserModel userModel);
        void AddRoleForUser(RoleModel model, UserModel user);
        UserModel GetUsersByEmail(string email);
    }
}
