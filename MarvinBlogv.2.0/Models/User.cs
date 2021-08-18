using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarvinBlogv._2._0.Models
{
    public class User : BaseEntity
    {
        [Required, MaxLength(150)]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string HashSalt { get; set; }

        public Role Role { get; set; }
        public int RoleId { get; set;}
        public List<Post> Posts { get; set; }
        public int PostId { get; set; }
        public List<Follower> Followers { get; set; }
        public List<UserRole> UserRole { get; set; }
    }
}
