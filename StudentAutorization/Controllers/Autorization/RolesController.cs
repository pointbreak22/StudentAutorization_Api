using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAutorization.Dtos.Autorization;
using StudentAutorization.Models.Autorization;
using System.Diagnostics;

namespace StudentAutorization.Controllers.Autorization
{
    // [Authorize(Roles ="Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {


        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;


          var createRole= CreateRole(new CreateRoleDto { RoleName = "Admin" });
          Debug.WriteLine(createRole.Result);
          createRole = CreateRole(new CreateRoleDto { RoleName = "User" });
          Debug.WriteLine(createRole.Result);


        }

      


        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleDto createRoleDto)
        {
            if (string.IsNullOrEmpty(createRoleDto.RoleName))
            {
                return BadRequest("Role name is required.");

            }
            var roleExist = await _roleManager.RoleExistsAsync(createRoleDto.RoleName);
            if (roleExist)
            {
                return BadRequest("Role already exist");
            }
            var roleResult = await _roleManager.CreateAsync(new IdentityRole(createRoleDto.RoleName));
            if (roleResult.Succeeded)
            {
                return Ok(new { message = "Role Created sucess." });
            }
            return BadRequest("Role created failed.");
        }

        [HttpGet]
        // [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<RoleResponseDto>>> GetRoles()
        {
            var roles = await _roleManager.Roles.Select(r => new RoleResponseDto
            {
                Id = r.Id,
                Name = r.Name,
              //  TotalUsers = _userManager.Users.Where(u => u.Roles.Contains(r)).Count()
                // TotalUsers = _userManager.GetUsersInRoleAsync(r.Name!).Result.Count()

            }).ToListAsync();
            return Ok(roles);
        }

        [HttpPost("assign")]
        public async Task<IActionResult> AssignRole([FromBody] RoleAssignDto roleAssignDto)
        {
            var user = await _userManager.FindByIdAsync(roleAssignDto.UserId);

            if (user == null)
            {
                return NotFound("User not found.");
            }
            var role = await _roleManager.FindByIdAsync(roleAssignDto.RoleId);
            if (role == null)
            {
                return NotFound("Role not found.");
            }
            var result = await _userManager.AddToRoleAsync(user, role.Name!);
            if (result.Succeeded)
            {
                return Ok(new { message = "Role assigned succesfully" });
            }
            var error = result.Errors.FirstOrDefault();
            return BadRequest(error!.Description);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            
            if (role is null)
            {
                return NotFound("Role not found.");
            }

            if (role.Name=="Admin" || role.Name=="User")
            {
                return BadRequest("Roles cannot be deleted User or Admin.");
            }
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return Ok(new { message = "Role deleted succesfully" });

            }
            return BadRequest("Role deletion failed.");
        }

    }
}
