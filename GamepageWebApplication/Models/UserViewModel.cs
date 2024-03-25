using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace GamepageWebApplication.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password and ConformationPassword must match")]
        public string ConfirmPassword { get; set; }

        public bool RememberMe { get; set; }

        public bool Isadmin { get; set; }
    }
}
