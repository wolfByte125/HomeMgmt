using FluentValidation;
using HomeMgmt.Models.UserModels;
using HomeMgmt.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeMgmt.Models.GeneralModels
{
    public class Home : IAuditableEntity
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public UserAccount? Owner { get; set; }

        [ForeignKey("Owner")]
        public string? OwnerId { get; set; }
        public List<UserAccount> HouseholdMembers { get; set; } = [];

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class HomeValidator : AbstractValidator<Home>
    {
        public HomeValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");

            RuleFor(x => x.OwnerId)
                .NotEmpty().WithMessage("Owner is required.");
        }
    }
}
