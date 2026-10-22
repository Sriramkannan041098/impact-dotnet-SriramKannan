using System.Data;
using EduSphere.IdentityService.Models;
using Microsoft.Data.SqlClient;
namespace EduSphere.IdentityService.Data;

public sealed class IdentityRepository(IConfiguration config) : IIdentityRepository
{
    private string ConnectionString => config.GetConnectionString("IdentityDb")
        ?? throw new InvalidOperationException("ConnectionStrings:IdentityDb is missing.");

    public async Task<UserRecord?> GetByEmailAsync(string email, CancellationToken ct)
    {
        await using var connection = new SqlConnection(ConnectionString);
        await using var command = new SqlCommand("dbo.usp_User_GetByEmail", connection) { CommandType = CommandType.StoredProcedure };
        command.Parameters.Add("@Email", SqlDbType.NVarChar, 256).Value = email;
        await connection.OpenAsync(ct);
        await using var reader = await command.ExecuteReaderAsync(ct);
        if (!await reader.ReadAsync(ct)) return null;
        return new UserRecord(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
            reader.GetString(3), reader.GetString(4), reader.GetInt32(5), reader.GetString(6), reader.GetBoolean(7));
    }

    public async Task<int> CreateAsync(string email, string displayName, string hash, string salt, int iterations, string role, CancellationToken ct)
    {
        await using var connection = new SqlConnection(ConnectionString);
        await using var command = new SqlCommand("dbo.usp_User_Create", connection) { CommandType = CommandType.StoredProcedure };
        command.Parameters.Add("@Email", SqlDbType.NVarChar, 256).Value = email;
        command.Parameters.Add("@DisplayName", SqlDbType.NVarChar, 120).Value = displayName;
        command.Parameters.Add("@PasswordHash", SqlDbType.NVarChar, 512).Value = hash;
        command.Parameters.Add("@PasswordSalt", SqlDbType.NVarChar, 256).Value = salt;
        command.Parameters.Add("@PasswordIterations", SqlDbType.Int).Value = iterations;
        command.Parameters.Add("@Role", SqlDbType.NVarChar, 30).Value = role;
        await connection.OpenAsync(ct);
        return Convert.ToInt32(await command.ExecuteScalarAsync(ct));
    }
}
