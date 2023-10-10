using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UserManagement.BusinessLogic.Models;

namespace UserManagement.Models
{
    public class RoleViewModel
    {
        public string RoleName { get; set; }
        public List<UserModel> Users { get; set; }
    }
}
