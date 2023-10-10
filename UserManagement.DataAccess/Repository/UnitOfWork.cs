using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.DataAccess.Interface;

namespace UserManagement.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserManagementContext userManagementContext;
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;

        public UnitOfWork(
            UserManagementContext userManagementContext,
            IUserRepository userRepository,
            IRoleRepository roleRepository
            )
        {
            this.userManagementContext = userManagementContext;
            this.roleRepository = roleRepository;
            this.userRepository = userRepository;
        }
        public IRoleRepository Role
        {
            get
            {
                return this.roleRepository;
            }
        }

        public IUserRepository User
        {
            get
            {
                return this.userRepository;
            }
        }

        public void Save()
        {
            userManagementContext.SaveChanges();
        }
    }
}
