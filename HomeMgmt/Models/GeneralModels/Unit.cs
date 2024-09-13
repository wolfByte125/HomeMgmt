using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace HomeMgmt.Models.GeneralModels
{
    public class Unit
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class UnitValidator : AbstractValidator<Unit>
    {
        public UnitValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(20).WithMessage("Name must not exceed 20 characters.");
        }
    }
}
