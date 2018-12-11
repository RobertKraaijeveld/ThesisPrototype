using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ThesisPrototype.ViewModels
{
    [BindProperties]
    public class LoginViewModel
    {
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
