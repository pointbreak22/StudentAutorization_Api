using Microsoft.AspNetCore.Mvc;

using StudentAutorization.Models.Main;
using StudentAutorization.Repositories.Interface;
using StudentAutorization.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentAutorization.Controllers.Main
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepositoty _teacherRepository;
        private readonly IPictureRepository _pictureRepository;

        public TeacherController(ITeacherRepositoty teacherRepository, IPictureRepository pictureRepository)
        {
            _teacherRepository = teacherRepository;
            _pictureRepository = pictureRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var teachers = await _teacherRepository.GetAllAsync();
            return Ok(teachers);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var teacher = await _teacherRepository.GetByIdAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return Ok(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TeacherRequest teacherRequest)
        {
            var teacher = new Teacher()
            {
                FIO = teacherRequest.FIO,
                Picture = _pictureRepository.GetByIdAsync(teacherRequest.PictureId).Result,




            };

            var createdTeacherResponse = await _teacherRepository.AddAsync(teacher);
            return CreatedAtAction(nameof(GetById), new { id = createdTeacherResponse.Id }, createdTeacherResponse);


        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TeacherRequest teacherRequest)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            teacher.FIO = teacherRequest.FIO;
            teacher.PictureId = teacherRequest.PictureId;
            teacher.Picture = _pictureRepository.GetByIdAsync(teacherRequest.PictureId).Result;
            await _teacherRepository.UpdateAsync(teacher);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            await _teacherRepository.DeleteAsync(teacher);
            return NoContent();
        }



    }
}
