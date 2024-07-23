using Microsoft.AspNetCore.Mvc;
using StudentAutorization.Models.Main;
using StudentAutorization.Repositories.Interface;
using StudentAutorization.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentAutorization.Controllers.Main
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {

        private readonly IGroupRepository _groupRepository;
        private readonly ITeacherRepositoty _teacherRepository;
        private readonly ICourseRepository _courseRepository;

        public GroupController(IGroupRepository groupRepository, ITeacherRepositoty teacherRepository, ICourseRepository courseRepository)
        {
            _groupRepository = groupRepository;
            _teacherRepository = teacherRepository;
            _courseRepository = courseRepository;
        }



        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var groups = await _groupRepository.GetAllAsync();

            return Ok(groups);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var group = await _groupRepository.GetByIdAsync(id);
            if (group == null)
            {
                return NotFound();
            }
            return Ok(group);
        }
        [HttpGet("{id}/students")]
        public async Task<IActionResult> GetStudents(int id)
        {

            var students = await _groupRepository.GetStudents(id);
            return Ok(students);
        }
        // POST api/<GroupController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GroupRequest groupRequest)
        {


            var course = await _courseRepository.GetByIdAsync(groupRequest.CourseId);
            var teacher = await _teacherRepository.GetByIdAsync(groupRequest.TeacherId);

            var group = new Group()
            {
                Name = groupRequest.Name,

                Specialty = groupRequest.Specialty,
                Year = groupRequest.Year,
                Course = course,

                Teacher = teacher,



            };

            var createdGrouprResponse = await _groupRepository.AddAsync(group);

            return CreatedAtAction(nameof(GetById), new { id = createdGrouprResponse.Id }, createdGrouprResponse);


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] GroupRequest groupRequest)
        {
            var group = await _groupRepository.GetByIdAsync(id);
            if (group == null)
            {
                return NotFound();
            }

            group.Name = groupRequest.Name;
            group.Specialty = groupRequest.Specialty;
            group.CourseId = groupRequest.CourseId;
            group.TeacherId = groupRequest.TeacherId;
            group.Course = _courseRepository.GetByIdAsync(groupRequest.CourseId).Result;
            group.Teacher = _teacherRepository.GetByIdAsync(groupRequest.TeacherId).Result;
            await _groupRepository.UpdateAsync(group);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var group = await _groupRepository.GetByIdAsync(id);
            if (group == null)
            {
                return NotFound();
            }
            await _groupRepository.DeleteAsync(group);
            return NoContent();
        }

    }
}
