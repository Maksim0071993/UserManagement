using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserManagement.DataAccess.Models;

namespace UserManagement.DataAccess.Interface
{
    public interface IUserRepository
    {
        void Add(User user);
        List<User> Get(Func<User, bool> func);
        IQueryable<User> GetAll();
        List<Role> GetRolesByUser(User user);
        bool DeleteUser(int id);
        void UpdateUser(User user);
        User GetById(int id);
        void AddRoleForUser(Role role, User user);
        User GetByEmail(string email);
    }
}
