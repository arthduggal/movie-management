using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagementAPI.ViewModel.Authentication
{
    public class RegistrationViewModel
    {

        [Required(ErrorMessage = "User Name is mandatory")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Password is mandatory")]
        public string Password { get; set; }
    }
}
