using System.ComponentModel.DataAnnotations;

namespace StudentAutorization.Dtos.Autorization
{
    public class CreateRoleDto
    {
        [Required(ErrorMessage = "Role Name is required.")]
        public string RoleName { get; set; } = null!;
    }
}
