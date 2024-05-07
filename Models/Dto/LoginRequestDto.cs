using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace NZWalks.API.Models.Dto
{
    public class LoginRequestDto
    {

        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
