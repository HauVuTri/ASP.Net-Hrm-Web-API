using System.ComponentModel.DataAnnotations;

namespace HRMAspNet.Models.Authencicate
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}