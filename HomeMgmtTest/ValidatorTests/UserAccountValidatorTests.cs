using FluentValidation.TestHelper;
using HomeMgmt;
using HomeMgmt.Models.UserModels;

namespace HomeMgmtTest.ValidatorTests
{
    public class UserAccountValidatorTests
    {
        private readonly UserAccountValidator _userAccountValidator = new();

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("hi")]
        public void UserAccountValidator_WhenUsernameIsInvalid_ShouldHaveError(string? username)
        {
            var result = _userAccountValidator.TestValidate(new UserAccount { Username = username });

            result.ShouldHaveValidationErrorFor(x => x.Username);
        }

        [Theory]
        [InlineData("bye")]
        [InlineData("bytr")]
        [InlineData("ohrem")]
        public void UserAccountValidator_WhenUsernameIsNotNull_ShouldNotHaveError(string username)
        {
            var result = _userAccountValidator.TestValidate(new UserAccount { Username = username });

            result.ShouldNotHaveValidationErrorFor(x => x.Username);
        }

        [Theory]
        [InlineData("John", "Doe")]
        [InlineData("Jane","Doe")]
        public void UserAccountValidator_WhenNamesAreNotNull_ShouldNotHaveError(string firstName, string lastName)
        {
            var result = _userAccountValidator.TestValidate(new UserAccount { FirstName = firstName, LastName = lastName });

            result.ShouldNotHaveValidationErrorFor(x => x.FirstName);
            result.ShouldNotHaveValidationErrorFor(x => x.LastName);
        }

        [Theory]
        [InlineData("")]
        [InlineData("987654321")]
        [InlineData("098765432")]
        [InlineData(null)]
        public void UserAccountValidator_WhenPhoneIsValid_ShouldNotHaveError(string? phoneNumber)
        {
            var result = _userAccountValidator.TestValidate(new UserAccount { PhoneNumber = phoneNumber });

            result.ShouldNotHaveValidationErrorFor(x => x.PhoneNumber);
        }

        [Theory]
        [InlineData("98765432")]
        [InlineData("0987654321")]
        public void UserAccountValidator_WhenPhoneIsInvalid_ShouldHaveError(string? phoneNumber)
        {
            var result = _userAccountValidator.TestValidate(new UserAccount { PhoneNumber = phoneNumber });

            result.ShouldHaveValidationErrorFor(x => x.PhoneNumber);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("invalidEmail")]
        [InlineData("hellogmail.com")]
        public void UserAccountValidator_WhenEmailIsInvalid_ShouldHaveError(string? email)
        {
            var result = _userAccountValidator.TestValidate(new UserAccount { Email = email });

            result.ShouldHaveValidationErrorFor(x => x.Email);
        }
        
        [Theory]
        [InlineData("example@yahoo.com")]
        [InlineData("ex@test.com")]
        public void UserAccountValidator_WhenEmailIsValid_ShouldNotHaveError(string? email)
        {
            var result = _userAccountValidator.TestValidate(new UserAccount { Email = email });

            result.ShouldNotHaveValidationErrorFor(x => x.Email);
        }
    }
}