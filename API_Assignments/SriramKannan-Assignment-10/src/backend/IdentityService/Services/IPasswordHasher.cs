namespace EduSphere.IdentityService.Services;
public interface IPasswordHasher
{
    (string Hash, string Salt, int Iterations) HashPassword(string password);
    bool Verify(string password, string hash, string salt, int iterations);
}
