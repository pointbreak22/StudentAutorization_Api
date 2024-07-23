using Microsoft.AspNetCore.Mvc;

using StudentAutorization.Models.Main;
using StudentAutorization.Repositories.Interface;
using StudentAutorization.ViewModel;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentAutorization.Controllers.Main
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IStudentRepository _studentRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IPictureRepository _pictureRepository;


        public StudentController(IStudentRepository studentRepository, IGroupRepository groupRepository, IPictureRepository pictureRepository)
        {
            _studentRepository = studentRepository;
            _groupRepository = groupRepository;
            _pictureRepository = pictureRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await _studentRepository.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var student = await _studentRepository.GetByIdAsync(id);
            if (student is null)
            {
                return NotFound();
            }
            return Ok(student);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentRequest studentRequest)
        {
            var student = new Student()
            {
                FIO = studentRequest.FIO,
                NumberPhone = studentRequest.NumberPhone,
                Group = _groupRepository.GetByIdAsync(studentRequest.GroupId).Result,
                Picture = _pictureRepository.GetByIdAsync(studentRequest.PictureId).Result,




            };

            var createdStudentResponse = await _studentRepository.AddAsync(student);
            return CreatedAtAction(nameof(GetById), new { id = createdStudentResponse.Id }, createdStudentResponse);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] StudentRequest studentRequest)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            student.FIO = studentRequest.FIO;
            student.NumberPhone = studentRequest.NumberPhone;
            student.PictureId = studentRequest.PictureId;
            student.GroupId = studentRequest.GroupId;
            student.Group = _groupRepository.GetByIdAsync(studentRequest.GroupId).Result;
            student.Picture = _pictureRepository.GetByIdAsync(studentRequest.PictureId).Result;

            await _studentRepository.UpdateAsync(student);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            await _studentRepository.DeleteAsync(student);
            return NoContent();
        }
    }
}
