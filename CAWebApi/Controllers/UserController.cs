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


        // GET: api/Users --Filtro por nombre o DNI de usuario (mismo campo debe ser serach)
        [HttpGet]
        public async Task<IActionResult> GetAll(string? filter = null)
        {
            var users = await _userService.GetAllAsync(filter);
            return Ok(users);
        }


        // GET: api/Users/{id}  --No recibe parámetros. Devuelve los detalles de un usuario específico por su ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetByIdAsync(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // PUT: api/Users/{id} --Recibe los detalles actualizados del usuario en el cuerpo del request y el ID del usuario en la URL.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, User updateUser)
        {
            int existingUser = await _userService.UpdateAsync(id, updateUser);
            if (existingUser == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }



        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            var createdBlog = await _userService.CreateAsync(user);

            return CreatedAtAction("GetByIdAsync", new { id = createdBlog.Id },
                createdBlog);
        }

 

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id)
        {

            int user = await _userService.DeleteAsync(id);
            if (user == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
