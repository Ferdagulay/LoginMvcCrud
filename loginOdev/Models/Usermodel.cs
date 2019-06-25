using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace loginOdev.Models
{
    public class Usermodel
    {

        public int UserId { get; set; }
        [DisplayName("Username")]
        [Required(ErrorMessage = "The field is required")]

        public string UserName { get; set; }
        [Required(ErrorMessage = "The field is required")]

        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Error { get; set; }

    }
}