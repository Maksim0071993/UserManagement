using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.DataAccess.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public List<Role> Roles { get; set; }
    }
}
