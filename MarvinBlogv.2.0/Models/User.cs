using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarvinBlogv._2._0.Models
{
    public class User : BaseEntity
    {
        [Required, MaxLength(150)]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string HashSalt { get; set; }

        public Role RoleId { get; set; }

        public Post Post { get; set; }
        public List<UserRole> UserRole { get; set; }
    }
}
