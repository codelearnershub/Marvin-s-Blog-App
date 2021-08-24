using System;
using System.ComponentModel.DataAnnotations;

namespace MarvinBlogv._2._0.Models
{
    public class UserViewModel
    {
    }

    public class CreateUserViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        [Required(ErrorMessage = "User name is required")]
        [Display(Name = "Full Name:")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "User E-mail is required")]
        [Display(Name = "E-mail Address:")]
        public string Email { get; set; }

        [Required(ErrorMessage = "User Password is required")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password!!")]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Name { get; set; }
        
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "User E-mail is required")]
        [Display(Name = "E-mail Address:")]
        public string Email { get; set; }

        [Required(ErrorMessage = "User Password is required")]
        [Display(Name = "Password:")]
        public string Password { get; set; }
    }
}
