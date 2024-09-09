using FluentValidation;
using HomeMgmt.Utils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HomeMgmt.Models.UserModels
{
    public class UserRole : IAuditableEntity
    {
        [Key]
        public int Id { get; set; }

        public string RoleName { get; set; } = string.Empty;

        public Permissions Permissions { get; set; } = new();

        public bool IsSuperAdmin { get; set; } = false;

        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        
        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }
    }
    public class UserRoleValidator : AbstractValidator<UserRole>
    {
        public UserRoleValidator()
        {
            RuleFor(x => x.RoleName)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
