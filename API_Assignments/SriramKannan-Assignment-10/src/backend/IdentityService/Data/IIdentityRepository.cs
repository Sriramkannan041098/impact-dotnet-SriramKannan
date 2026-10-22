using EduSphere.IdentityService.Models;
namespace EduSphere.IdentityService.Data;
public interface IIdentityRepository
{
    Task<UserRecord?> GetByEmailAsync(string email, CancellationToken ct);
    Task<int> CreateAsync(string email, string displayName, string hash, string salt, int iterations, string role, CancellationToken ct);
}
