using EhodBoutiqueEnLigne.Controllers;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace EhodBoutiqueEnLigne.Models.ViewModels
{
    public class LoginModel
    {
        private readonly IStringLocalizer<LoginModel> _localizer;

        public LoginModel(IStringLocalizer<LoginModel> localizer)
        {
            _localizer = localizer;
        }

        public LoginModel()
        {        }

        [Required(ErrorMessage ="MissingLoginName")]
        public string Name { get; set; }

        [Required(ErrorMessage = "MissingLoginPassword")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; } = "/";
    }
}