using EhodVenteEnLigne.Resources.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace EhodBoutiqueEnLigne.Models.ViewModels
{
    public class ProductViewModel
    {
        [BindNever]
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "ErrorMissingName", ErrorMessageResourceType = typeof(Product))]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Details { get; set; }

        [Required(ErrorMessageResourceName = "ErrorMissingStock", ErrorMessageResourceType = typeof(Product))]
        [RegularExpression("^[0-9]+$", ErrorMessageResourceName = "ErrorStockValue", ErrorMessageResourceType = typeof(Product))]
        [Range(minimum:0, maximum: int.MaxValue, ErrorMessageResourceName = "ErrorStockValue", ErrorMessageResourceType = typeof(Product))]
        public string Stock { get; set; }

        [Required(ErrorMessageResourceName = "ErrorMissingPrice", ErrorMessageResourceType = typeof(Product))]
        [RegularExpression("^\\d+(\\.\\d+)?$", ErrorMessageResourceName = "ErrorPriceValue", ErrorMessageResourceType = typeof(Product))]
        [Range(minimum: 0, maximum: double.MaxValue, ErrorMessageResourceName = "ErrorPriceValue", ErrorMessageResourceType = typeof(Product))]
        public string Price { get; set; }
    }
}
