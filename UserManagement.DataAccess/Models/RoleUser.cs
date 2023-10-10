using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.DataAccess.Models
{
    public class RoleUser
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }

    }
}
