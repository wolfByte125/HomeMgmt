using Microsoft.Identity.Client;

namespace HomeMgmt.DTOs.AuthDTOs.LoginDTOs
{
    public class LoginDTO
    {
        public string Username { get; set; } = string.Empty;
        
        public string Password { get; set; } = string.Empty;
    }
}
