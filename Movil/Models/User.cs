using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movil.Models
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Role { get; set; }
    }

    public class LoginUser
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Password { get; set; }
    }
}
