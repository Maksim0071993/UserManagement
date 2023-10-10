using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.BusinessLogic.Models;

namespace UserManagement.BusinessLogic.Interface
{
    public interface IRoleService
    {
        void AddRole(RoleModel model);
        RoleModel GetRoleById(int id);
        List<RoleModel> GetAllRoles();
        List<RoleModel> GetRolesByUser(UserModel userModel);
        RoleModel GetRoleByName(string name);
    }
}
