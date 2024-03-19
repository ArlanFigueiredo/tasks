using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemTasks.Models;
using SystemTasks.Repository.Interfaces;

namespace SystemTasks.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase {

        private readonly ITaskRepository _taskRepository;
        public TaskController(ITaskRepository taskRepository) {
            _taskRepository = taskRepository;
        }


        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> FindAllTasks() {
            List<TaskModel> tasks = await _taskRepository.FindAllTasks();
            return Ok(tasks);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<List<TaskModel>>> FindById(int id) {
            TaskModel tasks = await _taskRepository.FindById(id);
            return Ok(tasks);
        }


        [HttpPost]
        public async Task<ActionResult<TaskModel>> CreateTasks([FromBody] TaskModel taskModel) {
            TaskModel task = await _taskRepository.CreateTasks(taskModel);
            return Ok(task);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<TaskModel>> UpdateTasks([FromBody] TaskModel taskModel, int id) {
            TaskModel task = await _taskRepository.UpdateTasks(taskModel, id);
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskModel>> DeleteTasks(int id) {
            await _taskRepository.DeleteTasks(id);
            return Ok();
        }
    }
}
