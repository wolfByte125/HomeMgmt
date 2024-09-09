using HomeMgmt.DTOs.AuthDTOs.LoginDTOs;
using HomeMgmt.DTOs.AuthDTOs.PasswordDTOs;
using HomeMgmt.DTOs.UserDTOs.UserAccountDTOs;
using HomeMgmt.Models.UserModels;

namespace HomeMgmt.Services.AuthServices
{
    public interface IAuthService
    {
        Permissions Permissions { get; set; }
        UserAccount UserAccount { get; }
        UserRole UserRole { get; set; }

        bool ChangePassword(ChangePasswordDTO changePasswordDTO);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        string GetMyName();
        LoginReturnDTO Login(LoginDTO loginDTO);
        Task<UserAccount> RegisterUserAccount(RegisterUserAccountDTO registerDTO);
        bool ResetPassword(ResetPasswordDTO resetPasswordDTO);
    }
}
