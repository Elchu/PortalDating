using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalDating.API.Data;

namespace PortalDating.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpGet("register")]
        public async Task<IActionResult> Register(string username, string password)
        {
            if (await _authRepository.UserExists(username))
                return BadRequest("Użytkownik o takiej nazwie już istnieje!");

            var user = await _authRepository.Register(username, password);

            return StatusCode(201);
        }
    }
}