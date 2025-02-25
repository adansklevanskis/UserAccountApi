using UserAccountApi.Domain.Repository;


namespace UserAccountApi.Domain.Services;

public class UserService : IUserService
{
    
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<string> GetUserWelcomeMessageAsync(string userName)
    {
        var user = await _userRepository.GetUserByUserNameAsync(userName);
        if (user == null)
        {
            return @$"{MessagesConstants.WELCOME}
{MessagesConstants.USER_NOT_FOUND}";
        }

        return @$"{MessagesConstants.WELCOME}
Hello, {user}";

    }
}
