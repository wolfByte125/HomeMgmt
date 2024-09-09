
using HomeMgmt.Models.UserModels;

namespace HomeMgmt.DTOs.AuthDTOs.LoginDTOs
{
    public class LoginReturnDTO
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public UserAccount UserAccount { get; set; }
        public UserRole UserRole { get; set; }
        public DateTime ExpiresOn { get; set; }
        public string? Id { get; set; }
        public string UserAccountId { get; set; }
        public dynamic User { get; set; }
    }
}
