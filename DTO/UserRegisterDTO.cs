using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserRegisterDTO
    {

        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [MaxLength(20, ErrorMessage = "first name must be less than 20 characters long")]

        public string FirstName { get; set; }
        [MaxLength(20, ErrorMessage = "first name must be less than 20 characters long")]

        public string LastName { get; set; }

        public string Password { get; set; }
        public string? UserName { get; set; }

    }
}
