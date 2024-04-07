using ContactsList.Server.Model;
using ContactsList.Server.Services.AccountService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ContactsList.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;

        }


        [HttpGet]
        public async Task<ActionResult<List<ApplicationUser>>> GetAllUsers()
        {
            var result = await _accountService.GetAllUsers();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationUser>> GetSingleUser(string id)
        {
            var result = await _accountService.GetUser(id);
            return result != null ? Ok(result) : NotFound($"User with id={id}, doesn't exist");
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<List<ApplicationUser>>> AddUser(ApplicationUser user)
        {
            var result = await _accountService.AddUser(user);
            return Ok(result);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<List<ApplicationUser>>> UpdateUser(ApplicationUser request)
        {
            var result = await _accountService.UpdateUser(request);
            if (result == null)
                return NotFound($"User with id={request.Id}, doesn't exist");
            return Ok(result);
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<List<ApplicationUser>>> DeleteUser(ApplicationUser user)
        {
            var result = await _accountService.DeleteUser(user);
            if (result == null)
                return NotFound($"User doesn't exist");
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginRequest model)
        {
            var result = await _accountService.LoginAsync(model);
            if (result != null)
                return Ok(result);
            else
                return BadRequest(new { message = "Niepoprawna nazwa użytkownika lub hasło." });
        }

        [HttpGet("test")]
        [Authorize]
        public ActionResult<IEnumerable<string>> test()
        {
            return new string[] { "value1", "value2", "value3", "value4", "value5" };
        }
    }
}
