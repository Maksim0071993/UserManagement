using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserManagement.DataAccess.Interface;
using UserManagement.DataAccess.Models;

namespace UserManagement.DataAccess.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly UserManagementContext userManagmentContext;
        public RoleRepository(UserManagementContext restaurantContext)
        {
            userManagmentContext = restaurantContext;
        }

        public void Add(Role role)
        {
            userManagmentContext.Roles.Add(role);
        }

        public List<Role> Get(Func<Role, bool> func)
        {
            var roles = userManagmentContext.Roles.Where(func).ToList();

            return roles;
        }
        public List<Role> GetAll()
        {
            var allRoles = userManagmentContext.Roles.ToList();
            return allRoles;
        }
        public Role GetById(int id)
        {
            var role = userManagmentContext.Roles.Where(x => x.Id == id);
            return role.FirstOrDefault();
        }
        public Role GetRoleByName(string name)
        {
            var role = userManagmentContext.Roles.Where(x => x.RoleName == name);
            return role.FirstOrDefault();
        }
        public List<User> GetUsersByRoleName(Role role)
        {
            var roles = userManagmentContext.Roles.Where(x => x.Id == role.Id).ToList();
            return roles.FirstOrDefault().Users;
        }
    }
}
