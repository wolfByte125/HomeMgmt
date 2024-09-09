using FluentValidation.TestHelper;
using HomeMgmt;
using HomeMgmt.Models.UserModels;

namespace HomeMgmtTest.ValidatorTests
{
    public class UserAccountValidatorTests
    {
        private readonly UserAccountValidator _userAccountValidator = new();

        [Fact]
        public void UserAccountValidator_WhenUsernameIsNull_ShouldHaveError()
        {
            var result = _userAccountValidator.TestValidate(new UserAccount { Username = null });

            result.ShouldHaveValidationErrorFor(x => x.Username);
        }

        [Theory]
        [InlineData("bytr")]
        [InlineData("ohrem")]
        public void UserAccountValidator_WhenUsernameIsNotNull_ShouldNotHaveError(string username)
        {
            var result = _userAccountValidator.TestValidate(new UserAccount { Username = username });

            result.ShouldNotHaveValidationErrorFor(x => x.Username);
        }
        
    }
}