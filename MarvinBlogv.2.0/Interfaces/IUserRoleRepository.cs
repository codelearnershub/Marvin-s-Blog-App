using MarvinBlogv._2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvinBlogv._2._0.Interfaces
{
    public interface IUserRoleRepository
    {
        public UserRole AddUserRole(UserRole userRole);
        public UserRole UpdateUserRole(UserRole userRole);
        public void Delete(int id);
        public UserRole FindById(int id);
        public UserRole FindByName(string name);
    }
}
