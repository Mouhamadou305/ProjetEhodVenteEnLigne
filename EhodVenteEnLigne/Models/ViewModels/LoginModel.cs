using EhodBoutiqueEnLigne.Controllers;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;
using EhodBoutiqueEnLigne.Models;
using EhodVenteEnLigne.Resources.Models;

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

        [Required(ErrorMessageResourceName ="MissingLoginName", ErrorMessageResourceType = typeof(Login))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "MissingLoginPassword", ErrorMessageResourceType = typeof(Login))]
        public string Password { get; set; }

        public string ReturnUrl { get; set; } = "/";
    }
}