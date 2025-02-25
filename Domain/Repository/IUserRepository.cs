namespace UserAccountApi.Domain.Repository;

public interface IUserRepository
{
    Task<string> GetUserByUserNameAsync(string userName);
}
