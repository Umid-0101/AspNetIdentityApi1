using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetIdentityShared
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(90,MinimumLength =3)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 8)]
        //[DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 8)]
        //[DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}
