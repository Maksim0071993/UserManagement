using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.DataAccess.Models;

namespace UserManagement.DataAccess
{
    public class UserManagementContext : DbContext
    {
        public UserManagementContext()
        {
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LENOVO15ACL3-PM;Database=UserManagement;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
