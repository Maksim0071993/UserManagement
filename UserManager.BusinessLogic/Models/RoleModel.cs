using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.DataAccess.Models;

namespace UserManagement.BusinessLogic.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public List<UserModel> Users { get; set; }
    }
}
