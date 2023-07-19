using Microsoft.AspNetCore.Mvc;
using Moq;
using UserApp.Api.Controllers;
using UserApp.AppCore.DTOs.UserDTO;
using UserApp.AppCore.Results;
using UserApp.AppCore.Results.Bases;
using UserApp.BLL.Abstract;

namespace UserApp.NUnitTest
{
    public class UserControllerNUnitTests
    {
        private readonly Mock<IUserManager> _mockUserManager;
        private readonly UserController _userController;

        public UserControllerNUnitTests()
        {
            _mockUserManager = new Mock<IUserManager>();
            _userController = new UserController(_mockUserManager.Object);
        }

        [Test]
        public async Task AddPost_ReturnsSuccessResultWhenUserIsAdded()
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
            var result = await _userController.AddUser(userToAdd) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public async Task AddPost_ReturnsErrorResultWhenUserIsAdded()
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
            var result = await _userController.AddUser(userToAdd) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));
        }

    }
}
