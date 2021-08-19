using MarvinBlogv._2._0.Context;
using MarvinBlogv._2._0.Interfaces;
using MarvinBlogv._2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvinBlogv._2._0.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly BlogDbContext _dbContext;

        public UserRoleRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserRole AddUserRole(UserRole userRole)
        {
            _dbContext.UserRoles.Add(userRole);
            _dbContext.SaveChanges();
            return userRole;
        }

        public void Delete(int id)
        {
            var userRole = FindById(id);
            {
                if (userRole != null)
                {
                    _dbContext.UserRoles.Remove(userRole);
                    _dbContext.SaveChanges();
                }
            }
        }

        public UserRole FindById(int id)
        {
            return _dbContext.UserRoles.Find(id);
        }

        public UserRole FindByName(string name)
        {
            return _dbContext.UserRoles.Find(name);
        }

        public UserRole UpdateUserRole(UserRole userRole)
        {
            _dbContext.UserRoles.Update(userRole);
            _dbContext.SaveChanges();
            return userRole;       
        }
    }
}
