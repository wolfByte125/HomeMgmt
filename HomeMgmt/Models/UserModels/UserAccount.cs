using FluentValidation;
using HomeMgmt.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace HomeMgmt.Models.UserModels
{
    public class UserAccount : IAuditableEntity
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Username { get; set; }

        [NotMapped]
        public string Password { get; set; }

        [JsonIgnore]
        public byte[] PasswordHash { get; set; }

        [JsonIgnore]
        public byte[] PasswordSalt { get; set; }

        public string Status { get; set; } = USER_STATUS.ACTIVE;

        public int CountBans { get; set; } = 0;

        public UserRole? UserRole { get; set; }
        
        [ForeignKey("UserRole")]
        public int? UserRoleId { get; set; }

        // BASIC INFO

        public string FirstName { get; set; } = null!;

        public string MiddleName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;

        public string FullName => FirstName + " " + MiddleName + " " + LastName;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }

    public class UserAccountValidator : AbstractValidator<UserAccount>
    {
        public UserAccountValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.")
                .Length(3, 50).WithMessage("Username must be between 3 and 50 characters.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .Length(1, 50).WithMessage("First name must be between 1 and 50 characters.");

            RuleFor(x => x.LastName)
                .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("A valid email is required.");

            RuleFor(x => x.PhoneNumber)
                .Must(phone => string.IsNullOrEmpty(phone) || Regex.IsMatch(phone, @"(^([0-9]){9}$)"))
                .WithMessage("Phone number must be a valid format if provided.");
        }
    }
}
