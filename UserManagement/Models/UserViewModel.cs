using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UserManagement.BusinessLogic.Models;

namespace UserManagement.Models
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public List<RoleModel> Roles { get; set; }
    }
}
