using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNET.Services;
using RestWithASPNET.Data.VO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace RestWithASPNET.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Authorize("Bearer")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<UserVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Index()
        {
            return Ok(_userService.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(UserVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Show(long id)
        {
            var user = _userService.FindByID(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(UserVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Create([FromBody] UserVO user)
        {
            if (user == null) return BadRequest();
            return Ok(_userService.Create(user));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(UserVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Update([FromBody] UserVO user)
        {
            if (user == null) return BadRequest();
            return Ok(_userService.Update(user));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _userService.Delete(id);
            return NoContent();
        }
    }
}
