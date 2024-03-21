using AC.Domain.Enitites;
using CA.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc; 

namespace CAWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }        

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            var createdBlog = await _userService.CreateAsync(user);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdBlog.Id }, createdBlog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update (int id, User updateUser)
        {
            int existingUser = await _userService.UpdateAsync(id, updateUser);
            if (existingUser == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id)
        {
            int user = await _userService.DeleteAsync(id);
            if (user == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
