using FluentValidation;
using HomeMgmt.Models.GeneralModels;
using HomeMgmt.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeMgmt.Models.StockModels
{
    public class Item : IAuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        [Column (TypeName = "decimal(18, 2)")]
        public decimal Cost { get; set; }
        public Category? Category { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public Unit? Unit { get; set; }

        [ForeignKey("Unit")]
        public int? UnitId { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    public class ItemValidator : AbstractValidator<Item>
    {
        public ItemValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");

            RuleFor(x => x.Cost)
                .NotEmpty().WithMessage("Cost is required.");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Category is required.");
            
            RuleFor(x => x.UnitId)
                .NotEmpty().WithMessage("Unit is required.");
        }
    }
}
