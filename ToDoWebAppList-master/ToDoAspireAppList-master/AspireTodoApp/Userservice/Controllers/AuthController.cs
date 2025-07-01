using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Userservice.Models;
using Userservice.Services;

namespace Userservice.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly InMemoryUserStore _store;
        private readonly JwtTokenGenerator _tokenGenerator;
        private readonly PasswordHasher<User> _hasher = new();

        public AuthController(InMemoryUserStore store, JwtTokenGenerator tokenGenerator)
        {
            _store = store;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            if (_store.EmailExists(request.Email))
                return Conflict("User alreadyy exists");

            var user = new User { Email = request.Email };
            user.PasswordHash = _hasher.HashPassword(user, request.Password);
            _store.Add(user);

            return Created("", new { user.Id, user.Email });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _store.GetByEmail(request.Email);
            if (user == null)
                return Unauthorized("Invalid credentials");

            var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
            if (result == PasswordVerificationResult.Failed)
                return Unauthorized("Invalid credentials");

            var token = _tokenGenerator.GenerateToken(user);
            return Ok(new { token });
        }

    }


    public record RegisterRequest(string Email, string Password);

    public record LoginRequest(string Email, string Password);

}