using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EduSphere.IdentityService.Data;
using EduSphere.IdentityService.Models;
using Microsoft.IdentityModel.Tokens;

namespace EduSphere.IdentityService.Services;

public sealed class IdentityService(IIdentityRepository repository, IPasswordHasher hasher, IConfiguration config) : IIdentityService
{
    public async Task<AuthResponse> RegisterAsync(RegisterRequest request, CancellationToken ct)
    {
        var email = request.Email.Trim().ToLowerInvariant();
        if (string.IsNullOrWhiteSpace(email) || !email.Contains('@')) {
            throw new ArgumentException("A valid email is required."); 
        }

        if (request.Password.Length < 10) { 
            throw new ArgumentException("Password must contain at least 10 characters."); 
        }

        if (string.IsNullOrWhiteSpace(request.DisplayName)) { 
            throw new ArgumentException("Display name is required."); 
        }

        if (await repository.GetByEmailAsync(email, ct) is not null) { 
            throw new InvalidOperationException("Email is already registered."); 
        }

        var (hash, salt, iterations) = hasher.HashPassword(request.Password);
        var id = await repository.CreateAsync(email, request.DisplayName.Trim(), hash, salt, iterations, "Student", ct);
        return CreateToken(id, email, request.DisplayName.Trim(), "Student");
    }

    public async Task<AuthResponse> LoginAsync(LoginRequest request, CancellationToken ct)
    {
        var user = await repository.GetByEmailAsync(request.Email.Trim().ToLowerInvariant(), ct);
        if (user is null || !user.IsActive || !hasher.Verify(request.Password, user.PasswordHash, user.PasswordSalt, user.PasswordIterations))
            throw new UnauthorizedAccessException("Invalid email or password.");
        return CreateToken(user.Id, user.Email, user.DisplayName, user.Role);
    }

    private AuthResponse CreateToken(int id, string email, string name, string role)
    {
        var section = config.GetSection("Jwt");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(section["Key"]!));
        var expires = DateTime.UtcNow.AddMinutes(30);
        var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim("name", name),
            new Claim("role", role)
        };
        var token = new JwtSecurityToken(section["Issuer"], section["Audience"], claims,
            expires: expires, signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
        return new AuthResponse(new JwtSecurityTokenHandler().WriteToken(token), expires, name, role);
    }
}
