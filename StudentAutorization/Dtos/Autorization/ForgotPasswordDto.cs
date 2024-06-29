using System.ComponentModel.DataAnnotations;

namespace StudentAutorization.Dtos.Autorization
{
    public class ForgotPasswordDto
    {

        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
