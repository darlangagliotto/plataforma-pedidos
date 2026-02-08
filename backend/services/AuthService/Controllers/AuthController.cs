using AuthService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthService.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login(LoginRequest login)
    {
        Console.WriteLine($"Recebido -> Username: {login?.Username} |||| Password: {login?.Password}");

        if(login?.Username != "admin" || login.Password != "123")
        {
            return Unauthorized();   
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, login.Username),
            new Claim(ClaimTypes.Role, "Admin")
        };

        // Pega a chave JWT do Docker / variáveis de ambiente
        var keyString = Environment.GetEnvironmentVariable("Jwt__Key") 
                        ?? throw new InvalidOperationException("JWT Key não encontrada!");

        if (Encoding.UTF8.GetByteCount(keyString) < 32)
        {
            throw new InvalidOperationException(
                "A chave JWT precisa ter pelo menos 32 bytes para HS256!"
            );
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));

        // Cria as credenciais usando HS256
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // Pega issuer e audience do Docker / ambiente
        var issuer = Environment.GetEnvironmentVariable("Jwt__Issuer") ?? "auth-service";
        var audience = Environment.GetEnvironmentVariable("Jwt__Audience") ?? "order-service";

        // Gera o token
        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds
        );

        // Retorna o token
        return Ok(new
        {
            token = new JwtSecurityTokenHandler().WriteToken(token)
        });
    }
}