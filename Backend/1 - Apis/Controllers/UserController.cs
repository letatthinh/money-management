using ApiLayer.DataTransferObjects.UserGroup;
using DataLayer.DomainModels.UserGroup;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiLayer.Controllers
{
    /// <summary>
    /// User controller.
    /// </summary>
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Create a new user.
        /// The username and password can be seen
        /// </summary>
        /// <param name="createUserDto">The DTO for creating new user.</param>
        /// <returns>True when the user has been created successfully.</returns>
        /// <response code="200">The user has been created successfully.</response>
        [HttpPost]
        public async Task<ActionResult<bool>> CreateAsync([FromBody] CreateUserDto createUserDto)
        {
            User u = new User();
            u.UserName = "";
            return true;
        }

        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <param name="createUserDto">The DTO for creating new user.</param>
        /// <returns>True when the user has been created successfully.</returns>
        /// <response code="200">The user has been created successfully.</response>
        [HttpPost("aa")]
        public async Task<ActionResult<string>> CreateasdasdAsync([FromBody] CreateUserDto createUserDto)
        {
            /* Hash the password */
            User user = new User
            {
                UserName = createUserDto.UserName,
                Password = createUserDto.Password,
            };

            PasswordHasherOptions passwordHasherOptions = new PasswordHasherOptions()
            {
                CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3,
                IterationCount = 500000 // should larger than 100000
            };

            var passwordHasher = new PasswordHasher<User>(Options.Create(passwordHasherOptions));
            var hasedPassword = passwordHasher.HashPassword(user, user.Password);
            var result = passwordHasher.VerifyHashedPassword(user, hasedPassword, "Tets");
            var result2 = passwordHasher.VerifyHashedPassword(user, hasedPassword, "string");

            /* Create token */
            var key = "Hello key, this should be 128 bits for endcrypt";
            var _issuer = "Hello issuer 2";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, createUserDto.UserName),
                //new Claim(JwtRegisteredClaimNames.Email, createUserDto.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("Password", createUserDto.Password),
            };

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _issuer,
                claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: credentials);

            var encodeToken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodeToken;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<int>>> GetNumbers()
        {
            return new List<int>() { 1 };
        }
    }
}
