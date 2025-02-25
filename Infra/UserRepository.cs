using Dapper;
using System.Data;
using UserAccountApi.Domain;
using UserAccountApi.Domain.Repository;

namespace UserAccountApi.Infra;

public class UserRepository : IUserRepository
{
    private readonly IDbConnection _dbConnection;

    public UserRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<string> GetUserByUserNameAsync(string userName)
    {
        var user = await _dbConnection.QueryFirstOrDefaultAsync<User>("SELECT name from Users Where username = @Username", new { UserName = userName });
        return user?.Name;
    }
}
