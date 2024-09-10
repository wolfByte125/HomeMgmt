using FluentValidation;
using HomeMgmt.Models.GeneralModels;
using HomeMgmt.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeMgmt.Models.StockModels
{
    public class Stock : IAuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public Home? Home { get; set; }

        [ForeignKey("Home")]
        public string? HomeId { get; set; }
        public Item? Item { get; set; }

        [ForeignKey("Item")]
        public int? ItemId { get; set; }
        public decimal Quantity { get; set; } = 0;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class StockValidator : AbstractValidator<Stock>
    {
        public StockValidator()
        {
            RuleFor(x => x.HomeId)
                .NotEmpty().WithMessage("Home is required.");
        }
    }
}
