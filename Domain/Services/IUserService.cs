namespace UserAccountApi.Domain.Services;

public interface IUserService
{
    Task<string> GetUserWelcomeMessageAsync(string userName);
}
