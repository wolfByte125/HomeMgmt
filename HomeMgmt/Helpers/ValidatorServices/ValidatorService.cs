using FluentValidation;
using FluentValidation.Results;
using HomeMgmt.Models.UserModels;

namespace HomeMgmt.Helpers.ValidatorServices
{
    public class ValidatorService : IValidatorService
    {
        private readonly IValidator<UserAccount> _userAccountValidator;
        private readonly IValidator<UserRole> _userRoleValidator;

        public ValidatorService
            (
                IValidator<UserAccount> userAccountValidator,
                IValidator<UserRole> userRoleValidator
            )
        {
            _userRoleValidator = userRoleValidator;
            _userAccountValidator = userAccountValidator;
        }

        public void Validate(UserAccount userAccount)
        {
            ValidationResult result = _userAccountValidator.Validate(userAccount);

            if (!result.IsValid)
                throw new InvalidOperationException($"Validation Failed: {ParseValidationError(errors: result.Errors)}");
        }

        public void Validate(UserRole userRole)
        {
            ValidationResult result = _userRoleValidator.Validate(userRole);

            if (!result.IsValid)
                throw new InvalidOperationException($"Validation Failed: {ParseValidationError(errors: result.Errors)}");
        }

        private string ParseValidationError(List<ValidationFailure> errors)
        {
            var errorMessages = errors
                    .Select(x => x.ErrorMessage)
                    .ToList();

            var formattedErrorMessages = string.Join(Environment.NewLine, errorMessages);

            return formattedErrorMessages;
        }
    }
}
