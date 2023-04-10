using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetIdentityShared
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(90)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength =8)]
        public string  Password { get; set; }
        


    }
}
