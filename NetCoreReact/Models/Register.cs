using System.ComponentModel.DataAnnotations;

namespace NetCoreReact.Controllers
{
    public class Register
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}