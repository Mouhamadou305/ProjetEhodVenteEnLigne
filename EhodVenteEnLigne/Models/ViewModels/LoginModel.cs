using EhodBoutiqueEnLigne.Controllers;
using System.ComponentModel.DataAnnotations;
using EhodVenteEnLigne.Resources.Models;

namespace EhodBoutiqueEnLigne.Models.ViewModels
{
    public class LoginModel
    {
        public LoginModel()
        {        }

        [Required(ErrorMessageResourceName ="MissingLoginName", ErrorMessageResourceType = typeof(Login))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "MissingLoginPassword", ErrorMessageResourceType = typeof(Login))]
        public string Password { get; set; }

        public string ReturnUrl { get; set; } = "/";
    }
}