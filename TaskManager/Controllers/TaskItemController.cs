using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Dtos;
using TaskManager.Extensions;
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

        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public ActionResult AdminOnly()
        {
            return Ok("Welcome Admin");
        }


        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 5)
        {
            var userId = User.GetUserId();
            return Ok(await _service.GetAll(userId, page, pageSize));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskDto dto)
        {
            var userId = User.GetUserId();
            await _service.Create(userId, dto);
            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTaskDto dto)
        {
            var userId = User.GetUserId();
            await _service.Update(userId, id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.GetUserId();
            await _service.Delete(userId, id);
            return NoContent();
        }
    }
}
