using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.DataAccess.Models;

namespace UserManagement.DataAccess.Interface
{
    public interface IRoleRepository
    {
        void Add(Role role);
        List<Role> Get(Func<Role, bool> func);
        List<Role> GetAll();
        Role GetById(int id);
        List<User> GetUsersByRoleName(Role role);
        Role GetRoleByName(string name);
    }
}
