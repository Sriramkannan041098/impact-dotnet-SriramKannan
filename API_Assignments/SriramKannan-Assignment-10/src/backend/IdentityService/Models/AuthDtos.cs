namespace EduSphere.IdentityService.Models;

public sealed record RegisterRequest(string Email, string DisplayName, string Password);

public sealed record LoginRequest(string Email, string Password);

public sealed record AuthResponse(string AccessToken, DateTime ExpiresUtc, string DisplayName, string Role);

public sealed record UserRecord(
    int Id, string Email, 
    string DisplayName, 
    string PasswordHash,
    string PasswordSalt, 
    int PasswordIterations, 
    string Role, 
    bool IsActive);
