using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace EhodBoutiqueEnLigne.Models.ViewModels
{
    public class ProductViewModel
    {
        [BindNever]
        public int Id { get; set; }

        [Required(ErrorMessage = "ErrorMissingName")]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Details { get; set; }

        [Required(ErrorMessage = "MissingQuantity")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "StockNotANumber")]
        [Range(minimum: 0, maximum: int.MaxValue, ErrorMessage = "StockNotGreaterThanZero")]
        public string Stock { get; set; }

        [Required(ErrorMessage = "MissingPrice")]
        [RegularExpression("^\\d+(\\.\\d+)?$", ErrorMessage = "PriceNotANumber")]
        [Range(minimum: 0, maximum: double.MaxValue, ErrorMessage = "PriceNotGreaterThanZero")]
        public string Price { get; set; }
    }
}
