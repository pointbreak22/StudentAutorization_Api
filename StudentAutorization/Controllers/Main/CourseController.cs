using Microsoft.AspNetCore.Mvc;
using StudentAutorization.Models.Main;
using StudentAutorization.Repositories.Interface;
using StudentAutorization.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentAutorization.Controllers.Main
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }



        // GET: api/<CourseController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var courses = await _courseRepository.GetAllAsync();
            return Ok(courses);

        }
        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        // POST api/<CourseController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CourseRequest courseRequest)
        {
            var course = new Course()
            {
                Name = courseRequest.Name

            };

            var createdCourseResponse = await _courseRepository.AddAsync(course);
            return CreatedAtAction(nameof(GetById), new { id = createdCourseResponse.Id }, createdCourseResponse);


        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CourseRequest courseRequest)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            course.Name = courseRequest.Name;
            await _courseRepository.UpdateAsync(course);
            return NoContent();
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            await _courseRepository.DeleteAsync(course);
            return NoContent();
        }
    }
}
