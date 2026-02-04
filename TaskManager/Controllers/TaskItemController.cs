using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Dtos;
using TaskManager.Interfaces;

namespace TaskManager.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TaskItemController : ControllerBase
    {
        private readonly ITaskService _service;

        public TaskItemController(ITaskService service)
        {
            _service = service;
        }

        [Authorize(Roles ="Admin")]
        [HttpGet("admin")]
        public ActionResult AdminOnly()
        {
            return Ok("Welcome Admin");
        }


        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 5)
        {
            return Ok(await _service.GetAll(page, pageSize));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskDto dto)
        {
            await _service.Create(dto);
            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTaskDto dto)
        {
            await _service.Update(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}
