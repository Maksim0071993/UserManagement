using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.DataAccess.Interface
{
    public interface IUnitOfWork
    {
        public IRoleRepository Role { get; }
        public IUserRepository User { get; }

        public void Save();
    }
}
