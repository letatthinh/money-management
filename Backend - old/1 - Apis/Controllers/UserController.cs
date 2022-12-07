using ApiLayer.Data.DataTransferObjects.UserGroup;
using DataLayer.DomainModels.UserGroup;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace ApiLayer.Controllers
{
    /// <summary>
    /// User controller.
    /// </summary>
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IHttpContextAccessor _contextAccessor;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contextAccessor"></param>
        public UserController(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        /// <summary>
        /// Create a new user.
        /// The username and password can be seen
        /// </summary>
        /// <param name="createUserDto">The DTO for creating new user.</param>
        /// <returns>True when the user has been created successfully.</returns>
        /// <response code="200">The user has been created successfully.</response>
        [HttpPost]
        public async Task<ActionResult<string?>> SignUp([FromBody] CreateUserDto createUserDto)
        {
            User u = new User();
            u.UserName = "";


            /* Create token */
            var key = "Ld^d753GmWU86HFk";
            var _issuer = "acackt!x0V7^K64915VveXJo3rOk^sQ0LZCjLFcQ";
            var _audience = "5vkskuA#S!OX4^wC#H3cW2mhgI48qpT3$TI1weeh";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, createUserDto.DisplayName),
                new Claim(ClaimTypes.Email, createUserDto.Email),
                new Claim("Password", "Nice!"),
            };

            var roles = new List<string>() { "A", "B" };
            roles.ForEach(x => claims.Add(new Claim(ClaimTypes.Role, x)));

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims,
                expires: DateTime.UtcNow.AddSeconds(10),
                signingCredentials: credentials);

            var encodeToken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodeToken;
        }

        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <param name="createUserDto">The DTO for creating new user.</param>
        /// <returns>True when the user has been created successfully.</returns>
        /// <response code="200">The user has been created successfully.</response>
        private async Task<ActionResult<string>> SignIn([FromBody] CreateUserDto createUserDto)
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

        [Authorize(Roles = "B")]
        [HttpGet("numbers")]
        public async Task<ActionResult<List<int>>> GetNumbers()
        {
            _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
            return new List<int>() { 1, 2, 3, 4, 5 };
        }

        [Authorize(Roles = "A")]
        [HttpGet("token-data")]
        public async Task<ActionResult<List<string>>> GetTokenData()
        {
            var name = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            var email = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
            var role = _contextAccessor.HttpContext.User.FindAll(ClaimTypes.Role);
            var password = _contextAccessor.HttpContext.User.FindFirstValue("Password");

            var result = new List<string>() { name, email, password };
            result.AddRange(role.Select(x => x.Value));
            return result;
        }
    }
}
