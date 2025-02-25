

using Moq;
using UserAccountApi.Domain.Repository;
using UserAccountApi.Domain.Services;
using FluentAssertions;
using UserAccountApi.Domain;

namespace UserAccountTest;

public class UserServiceTest
{
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly UserService _userService;

    public UserServiceTest()
    {
        _mockUserRepository = new Mock<IUserRepository>();
        _userService = new UserService(_mockUserRepository.Object);
    }

    [Fact]
    public async Task GetUserWelcomeMessageAsyncShouldReturnAValidUserTestAsync()
    {
        //Arrange
        var user = "David";
        _mockUserRepository.Setup(c => c.GetUserByUserNameAsync(It.IsAny<string>())).ReturnsAsync("David");

        //Act
        var result = await _userService.GetUserWelcomeMessageAsync(user);

        //Assert
        result.Should()
            .NotBeNull()
            .And.Contain(MessagesConstants.WELCOME)
            .And.Contain(user);

    }

    [Fact]
    public async Task GetUserWelcomeMessageAsyncShouldNotFoundUserTestAsync()
    {
        //Arrange
        var user = "Davi";

        //Act
        var result = await _userService.GetUserWelcomeMessageAsync(user);

        //Assert
        result.Should()
            .NotBeNull()
            .And.Contain(MessagesConstants.WELCOME)
            .And.Contain(MessagesConstants.USER_NOT_FOUND)
            .And.NotContain(user);

    }
}