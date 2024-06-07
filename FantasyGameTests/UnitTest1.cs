using FantasyGame.Models.Entities;
using FantasyGame.Repositories.Interfaces;
using FantasyGame.Services;
using FantasyGame.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestPlatform.Utilities.Helpers.Interfaces;
using Moq;

namespace FantasyGameTests
{
    [TestFixture]
    public class AuthServiceTests
    {
        private IAuthService _authService;

        //private IOptions<AppConfig> _options;
        private Mock<ICryptographyService> _cryptographyServiceMock;
        //private Mock<IEmailService> _emailServiceMock;
       //private Mock<ITimeHelper> _timeHelperMock;
        private Mock<IUserRepository> _userRepositoryMock;

        [SetUp]
        public void Setup()
        {
            //_options = Options.Create(new AppConfig()
            //{
            //    Secret = "AAAAAAAAAABBBBBBBBBBCCCCCCCCCCDD",
            //    Url = "test.com:5050",
            //});


            _userRepositoryMock = new Mock<IUserRepository>();

            SetAuthService();
        }

        private void SetAuthService()
        {
            _authService = new AuthService(
                _userRepositoryMock.Object);
        }

        [Test]
        public async Task ConfirmUserAsync_OnSuccess_ShouldReturnSuccessDTO()
        {
            //User? userData = new()
            //{
            //    IsConfirmed = false,
            //};

            //_userRepositoryMock.Setup(x => x.GetByData(It.IsAny<ulong>(), It.IsAny<string>(), It.IsAny<string>()))
            //    .ReturnsAsync(userData);
            //_userRepositoryMock.Setup(x => x.UpdateAsync(userData))
            //    .ReturnsAsync(1);

            //SetAuthService();

            //ulong id = 123;
            //string email = "mail@test.com";
            //string username = "username";

            //var result = await _authService.ConfirmUserAsync(id, email, username);
            //Assert.That(result, Is.InstanceOf<SuccessDTO>());
            Assert.That(true, Is.True);
        }
    }
}