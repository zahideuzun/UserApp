using Microsoft.AspNetCore.Mvc;
using Moq;
using NLog;
using UserApp.Api.Controllers;
using UserApp.AppCore.DTOs.UserDTO;
using UserApp.AppCore.Results;
using UserApp.AppCore.Results.Bases;
using UserApp.BLL.Abstract;

namespace UserApp.XUnitTest
{
    public class UserControllerTests : IDisposable

    {
        private readonly Mock<IUserManager> _mockUserManager;
        private readonly UserController _userController;
        private readonly Logger _logger;


        public UserControllerTests()
        {
            _mockUserManager = new Mock<IUserManager>();
            _userController = new UserController(_mockUserManager.Object);
            _logger = LogManager.GetCurrentClassLogger();
            LogManager.Setup().LoadConfigurationFromFile("nlog.config");
        }
        
        [Fact]
        public void GetAll_ReturnsAListOfUsers()
        {
            List<UserDTO> expectedUsers = new List<UserDTO>
            {
                new UserDTO { Id = 1, Name = "Zahide" },
                new UserDTO { Id = 2, Name = "iskender" },
                new UserDTO { Id = 3, Name = "Berkay" }
            };

            _mockUserManager.Setup(service => service.GetAll()).Returns(expectedUsers.AsQueryable);

            // Act
            var result = _userController.GetAllUsers();

            // Assert
            Assert.Equal(expectedUsers, result);
        }

        [Theory]
        [InlineData(1)]
        public void Get_ReturnsAUserWithMatchingId(int userId)
        {
            // Arrange
            var expectedUser = new UserDTO { Id = 1, Name = "Zahide" };

            _mockUserManager.Setup(service => service.Get(userId)).Returns(expectedUser);

            // Act
            var result = _userController.UserGet(userId);

            // Assert
            Assert.Equal(expectedUser, result);
            Assert.IsType<UserDTO>(result);
        }

        [Fact]
        public async void AddPost_ReturnsSuccessResultWhenUserIsAdded()
        {
            // Arrange
            var userToAdd = new AddUserDTO
            {
                Name = "Kerem",
                Surname = "Yardım",
                PhoneNumber = "13245679801",
                Email = "ky@gmail.com",
                ImageURL = "12345keremfoto.jpg",
            };
            var expectedServiceResult = Task.FromResult<Result>(new SuccessResult());

            _mockUserManager
                .Setup(service => service.AddAsync(userToAdd))
                .Returns(expectedServiceResult);

            // Act
            var result = await _userController.AddUser(userToAdd);

            // Assert
            Assert.True(result is ObjectResult objectResult && objectResult.StatusCode == 200);
            Assert.NotNull(result);
            _mockUserManager.Verify(repo => repo.AddAsync(userToAdd), Times.Once);
        }

        // ayni email adresiyle yeni bir ekleme yapamayacagim icin error result donecek. status code yine 200 fakat result tipi farkli?
        [Fact]
        public async void AddPost_ReturnsErrorResultWhenUserIsAdded()
        {
            // Arrange
            var userToAdd = new AddUserDTO
            {
                Name = "Kerem",
                Surname = "Yardım",
                PhoneNumber = "13245679801",
                Email = "k@gmail.com",
                ImageURL = "12345keremfoto.jpg",
            };
            var expectedServiceResult = Task.FromResult<Result>(new ErrorResult());

            _mockUserManager
                .Setup(service => service.AddAsync(userToAdd))
                .Returns(expectedServiceResult);

            // Act
            var result = await _userController.AddUser(userToAdd);

            // Assert
            Assert.True(result is ObjectResult objectResult && objectResult.StatusCode == 200);
        }

        [Fact]
        public async void UpdatePost_ReturnsSuccessResultWhenUserIsUpdated()
        {
            // Arrange
            var commentToUpdate = new UpdateUserDTO
            {
                Name = "Zahide",
                Surname = "zahide",
                PhoneNumber = "13245679801",
                Email = "zui@gmail.com",
                ImageURL = "12345zahidefoto.jpg",
            };
            var expectedServiceResult = Task.FromResult<Result>(new SuccessResult());

            _mockUserManager.Setup(service => service.UpdateAsync(1, commentToUpdate)).Returns(expectedServiceResult);

            var logEvent = new LogEventInfo(LogLevel.Info, _logger.Name, "Test başladı.");
            logEvent.Properties["TestDateTime"] = DateTime.Now;
            _logger.Log(logEvent);

            // Act
            var result = await _userController.UserUpdate(1, commentToUpdate);

            // Assert
            Assert.True(result is ObjectResult objectResult && objectResult.StatusCode == 200);

            logEvent = new LogEventInfo(LogLevel.Info, _logger.Name, "Test bitti.");
            logEvent.Properties["TestDateTime"] = DateTime.Now;
            logEvent.Properties["TestSuccess"] = true; // Test başarılı olduğunu farz edelim, test sonucunu buna göre ayarlayabilirsiniz
            _logger.Log(logEvent);
        }

        [Fact]
        public async void DeletePost_ReturnsSuccessResultWhenUserIsDeleted()
        {
            // Arrange
            var expectedServiceResult = Task.FromResult<Result>(new SuccessResult());

            _mockUserManager.Setup(service => service.DeleteAsync(1)).Returns(expectedServiceResult);

            // Act
            var result = await _userController.Delete(1);

            // Assert
            Assert.True(result is ObjectResult objectResult && objectResult.StatusCode == 200);
        }

        public void Dispose()
        {
            LogManager.Shutdown();
        }

        //[Fact]
        //public void SaveFileToTempLocation_ShouldSaveFileAndReturnFileName()
        //{
        //    // Arrange
        //    var formFileMock = new Mock<IFormFile>();
        //    string fileName = "test.jpg";
        //    formFileMock.Setup(f => f.FileName).Returns(fileName);

        //    var fileStringBase = new FileStringBase();

        //    // Act
        //    string result = fileStringBase.SaveFileToTempLocation(formFileMock.Object);

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.EndsWith(".jpg", result);

        //    // Check if the file exists in the expected location
        //    string expectedLocation = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", result);
        //    Assert.True(File.Exists(expectedLocation));

        //    // Clean up the test file
        //    File.Delete(expectedLocation);
        //}







    }
}
