using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using StudentAutorization.Models.Main;
using StudentAutorization.Repositories.Interface;
using StudentAutorization.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentAutorization.Controllers.Main
{
    [Route("api/[controller]")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        private readonly IPictureRepository _pictureRepository;

        public PictureController(IPictureRepository pictureRepository)
        {
            _pictureRepository = pictureRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pictures = await _pictureRepository.GetAllAsync();
            return Ok(pictures);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var picture=await _pictureRepository.GetByIdAsync(id);
            if (picture == null)
            {
                return NotFound();
            }
            return Ok(picture);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PictureRequest pictureRequest)
        {
            var picture = new Picture()
            {
                Src = pictureRequest.Src

            };

            var createdPictureResponse = await _pictureRepository.AddAsync(picture);
            return CreatedAtAction(nameof(GetById),new {id= createdPictureResponse.Id},createdPictureResponse);


        }
        [HttpPut("{id}")]
        public async  Task<IActionResult> Put (int id, [FromBody] PictureRequest pictureRequest)
        {
            var picture=await _pictureRepository.GetByIdAsync (id);
            if  (picture == null)
            {
                return NotFound();
            }
            picture.Src = pictureRequest.Src;
            await _pictureRepository.UpdateAsync(picture);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var picture=await _pictureRepository.GetByIdAsync(id);
            if (picture == null)
            {
                return NotFound();
            }
            await _pictureRepository.DeleteAsync(picture);
            return NoContent();
        }


        
    }
}
