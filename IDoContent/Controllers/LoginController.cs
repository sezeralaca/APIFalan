﻿using IDoContent.Data.Entity;
using IDoContent.Services;
using Microsoft.AspNetCore.Mvc;

namespace IDoContent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly JwtService _jwtService;

        public LoginController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            // Replace with your actual user validation logic (don't store plain text passwords)
            if (!IsValidUser(login))
            {
                return Unauthorized();
            }

            var user = GetUserFromCredentials(login); // Replace with logic to get user object

            var token = _jwtService.GenerateToken(user);

            return Ok(new { token = token });
        }
        private bool IsValidUser(LoginModel login)
        {
            // Replace this with your actual user validation logic (e.g., compare with a database)
            return login.Username == "admin" && login.Password == "password123"; // Example (replace with real logic)
        }

        private User GetUserFromCredentials(LoginModel login)
        {
            // Replace this with logic to retrieve the User object based on validated credentials.
            return new User { Id = 1, Username = "admin" }; // Example (replace with real logic)
        }
    }
}
