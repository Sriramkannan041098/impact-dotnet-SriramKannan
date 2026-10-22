using EduSphere.IdentityService.Services;
using Xunit;
namespace IdentityService.Tests;
public class PasswordHasherTests
{
    [Fact]
    public void HashPassword_AndVerify_ReturnsTrueForOriginalPassword()
    {
        var hasher = new Pbkdf2PasswordHasher();
        var (hash, salt, iterations) = hasher.HashPassword("A-strong-demo-password-123!");
        Assert.True(hasher.Verify("A-strong-demo-password-123!", hash, salt, iterations));
        Assert.False(hasher.Verify("wrong-password", hash, salt, iterations));
        Assert.NotEqual("A-strong-demo-password-123!", hash);
    }
}
