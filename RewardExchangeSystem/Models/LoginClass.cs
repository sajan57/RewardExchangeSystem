using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RewardExchangeSystem.Models
{
    public class LoginClass
    {
        [Required(ErrorMessage ="Please Enter Your UserName !")]
        [Display(Name ="Enter Username:")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Password !")]
        [Display(Name = "Enter Password:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}