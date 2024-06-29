using Microsoft.AspNetCore.Mvc;
using StudentAutorization.Models.Main;
using StudentAutorization.Repositories.Interface;
using StudentAutorization.ViewModel;
using System.Threading.Tasks;

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


        // GET: api/<GroupController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var groups = await _groupRepository.GetAllAsync();
            return Ok(groups);
        }

        // GET api/<GroupController>/5
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
        // POST api/<GroupController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GroupRequest groupRequest)
        {


            var course = await _courseRepository.GetByIdAsync(groupRequest.CourseId);
            var teacher = await _teacherRepository.GetByIdAsync(groupRequest.TeacherId);

            var group = new Group()
            {
                Name = groupRequest.Name,
           //     CourseId = groupRequest.CourseId,
                Course=course,
            //    TeacherId= groupRequest.TeacherId,
                Teacher=teacher,



            };

            var createdGrouprResponse = await _groupRepository.AddAsync(group);

            return NoContent(); 
            //return CreatedAtAction(nameof(GetById), new { id = createdGrouprResponse.Id }, createdGrouprResponse);


        }

        // PUT api/<GroupController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] GroupRequest groupRequest)
        {
            var group = await _groupRepository.GetByIdAsync(id);
            if (group == null)
            {
                return NotFound();
            }

            group.Name = groupRequest.Name;
            group.CourseId = groupRequest.CourseId;
            group.TeacherId = groupRequest.TeacherId;
            group.Course = _courseRepository.GetByIdAsync(groupRequest.CourseId).Result;
            group.Teacher = _teacherRepository.GetByIdAsync(groupRequest.TeacherId).Result;
            await _groupRepository.UpdateAsync(group);
            return NoContent();
        }

        // DELETE api/<GroupController>/5
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
