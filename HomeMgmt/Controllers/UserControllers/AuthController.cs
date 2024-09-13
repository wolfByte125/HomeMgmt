using FluentValidation;
using HomeMgmt.DTOs.AuthDTOs.LoginDTOs;
using HomeMgmt.DTOs.AuthDTOs.PasswordDTOs;
using HomeMgmt.DTOs.UserDTOs.UserAccountDTOs;
using HomeMgmt.Helpers.ValidatorServices;
using HomeMgmt.Models.UserModels;
using HomeMgmt.Services.AuthServices;
using HomeMgmt.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeMgmt.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IValidatorService _validatorService;

        public AuthController(IAuthService authService, IValidatorService validatorService)
        {
            _authService = authService;
            _validatorService = validatorService;
        }

        [HttpGet("check/token"), Authorize]
        public ActionResult<string> GetTokenValid()
        {
            try
            {
                var userName = _authService.GetMyName();
                return Ok(new { Status = true, UserName = userName });
            }
            catch (Exception ex)
            {
                return this.ParseException(exception: ex);
            }
        }

        [HttpGet("check/account"), Authorize(Policy = AUTHORIZATION.EXCLUDE_INACTIVE)]
        public ActionResult<string> GetAccountValid()
        {
            try
            {
                var userName = _authService.GetMyName();
                return Ok(new { Status = true, UserName = userName });
            }
            catch (Exception ex)
            {
                return this.ParseException(exception: ex);
            }
        }


        [HttpPost("register")]
        public async Task<ActionResult> RegisterUserAccount(RegisterUserAccountDTO registerDTO)
        {
            try
            {
                _validatorService.Validate(new UserAccount()
                {
                    Username = registerDTO.Username,
                    FirstName = registerDTO.FirstName,
                    MiddleName = registerDTO.MiddleName,
                    LastName = registerDTO.LastName,
                    Email = registerDTO.Email,
                    PhoneNumber = registerDTO.PhoneNumber,
                    Password = registerDTO.Password
                });

                return Ok(await _authService.RegisterUserAccount(registerDTO));
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }

        [HttpPost("login")]
        public ActionResult Login(LoginDTO loginDTO)
        {
            try
            {
                return Ok(_authService.Login(loginDTO));
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }

        [HttpPost("changePassword"), Authorize]
        public ActionResult ChangePassword(ChangePasswordDTO changePasswordDTO)
        {
            try
            {
                return Ok(_authService.ChangePassword(changePasswordDTO));
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }

        [HttpPost("resetPassword"), Authorize(Policy = AUTHORIZATION.EXCLUDE_INACTIVE)]
        public ActionResult ResetPassword(ResetPasswordDTO resetPasswordDTO)
        {
            try
            {
                return Ok(_authService.ResetPassword(resetPasswordDTO));
            }
            catch (Exception ex)
            {
                return this.ParseException(ex);
            }
        }
    }
}
