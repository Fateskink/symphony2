using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using symphony2.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using symphony2.Utils;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost("signin")]
    public IActionResult SignIn([FromBody] User user)
    {
        if (IsValidUser(user.Email, user.Password))
        {

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Email ?? ""),
                new Claim(ClaimTypes.Email, user.Email ?? "")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: creds
            );

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

        return Unauthorized();
    }


  private bool IsValidUser(string? email, string? password)
  {
    if (email == null || password == null)
    {
        return false;
    }
      using (var context = new SymphonyContext())
      {
          var user = context.User.FirstOrDefault(u => u.Email == email);

          if (user == null)
          {
              return false;
          }

          // Calculate the SHA1 hash of the provided password
          var hashedPassword = PasswordUtils.EncryptPassword(password);

          // Compare the hashed password with the one stored in the database
          return user.Password == hashedPassword;
      }
  }
}
