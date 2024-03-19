using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemTasks.Models;
using SystemTasks.Repository.Interfaces;

namespace SystemTasks.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {

        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository) {
            _userRepository = userRepository;
        }


        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> FindAllUsers() {
            List<UserModel> user = await _userRepository.FindAllUsers();
            return Ok(user);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserModel>>> FindById(int id) {
            UserModel user = await _userRepository.FindById(id);
            return Ok(user);
        }


        [HttpPost]
        public async Task<ActionResult<UserModel>> CreateUser([FromBody] UserModel userModel) {
            UserModel user = await _userRepository.CreateUser(userModel);
            return Ok(user);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> UpdateUser([FromBody] UserModel userModel, int id) {
            UserModel user = await _userRepository.UpdateUser(userModel, id);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> DeleteUser(int id) {
            await _userRepository.DeleteUser(id);
            return Ok();
        }
    }
}
