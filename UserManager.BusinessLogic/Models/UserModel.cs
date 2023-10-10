using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.BusinessLogic.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public List<RoleModel> Roles { get; set; }
    }
}
