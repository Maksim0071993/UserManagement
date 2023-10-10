using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

using UserManagement.DataAccess.Interface;
using UserManagement.DataAccess.Models;

namespace UserManagement.DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManagementContext userManagmentContext;
        public UserRepository(UserManagementContext restaurantContext)
        {
            userManagmentContext = restaurantContext;
        }

        public void Add(User user)
        {
            userManagmentContext.Users.Add(user);
        }
        public void AddRoleForUser(Role role, User user)
        {
            user.Roles.Add(role);
        }

        public List<User> Get(Func<User, bool> func)
        {
            var users = userManagmentContext.Users.Include(x => x.Roles).Where(func).ToList();

            return users;
        }
        public User GetById(int id)
        {
            var users = userManagmentContext.Users.Include(x => x.Roles).Where(x => x.Id == id);

            return users.FirstOrDefault();
        }
        public IQueryable<User> GetAll()
        {
            var allUsers = userManagmentContext.Users.Include(x => x.Roles).AsQueryable();
            
            return allUsers;
        }
        public User GetByEmail(string email)
        {
            var user = userManagmentContext.Users.Include(x => x.Roles).Where(x => x.Email == email);
            return user as User;
        }
        public List<Role> GetRolesByUser(User user)
        {
            var users = userManagmentContext.Users.Where(x => x.Id == user.Id);
            return users.FirstOrDefault().Roles;
        }
        public bool DeleteUser(int id)
        {
            var user = userManagmentContext.Users.Find(id);
            bool result;
            if (user != null)
            {

                userManagmentContext.Entry(user).State = EntityState.Deleted;
                result = true;
            }
            else
                result = false;
            return result;



            //userManagmentContext.Users.Remove(user);
        }
        public void UpdateUser(User user)
        {
            userManagmentContext.Users.Update(user);
        }
    }
}
