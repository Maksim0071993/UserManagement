using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.DataAccess.Models;

namespace UserManagement.DataAccess.Repository
{
    public class RoleUserRepository
    {
        private readonly UserManagementContext userManagmentContext;
        public RoleUserRepository(UserManagementContext restaurantContext)
        {
            userManagmentContext = restaurantContext;
        }

        public void Add(RoleUser user)
        {

        }
    }
}
