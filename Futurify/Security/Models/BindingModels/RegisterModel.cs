using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Models.BindingModels
{
    public class RegisterModel
    {
        [EmailAddress]
        public string Email { get; set; }

        //public string Password { get; set; }
        public string PhoneNumner { get; set; }
        //public string ConfirmPassword { get; set; }
        //public string Address { get; set; }

    }
}
