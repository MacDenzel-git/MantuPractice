using MantuPractice.Application.GenericCrudService;
using MantuPractice.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MantuPractice.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICrudService<UserDTO> _service;

        public UserController(ICrudService<UserDTO> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _service.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserDTO dto)
            => Ok(await _service.Create(dto));

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserDTO dto)
            => Ok(await _service.Update(dto));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok(new { message = "Deleted successfully" });
        }
    }

}
