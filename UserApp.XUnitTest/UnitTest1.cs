//using Moq;
//using UserApp.Api.Controllers;
//using UserApp.AppCore.DTOs.UserDTO;
//using UserApp.BLL.Abstract;

//namespace UserApp.XUnitTest
//{
//    public class UnitTest1
//    {
//        public class UserControllerTests
//        {
//            private readonly Mock<IUserManager> _mockUserManager;
//            private readonly UserController _userController;

//            public UserControllerTests()
//            {
//                _mockUserManager = new Mock<IUserManager>();
//                _userController = new UserController(_mockUserManager.Object);
//            }

//            [Fact]
//            public void GetAll_ShouldReturnListOfCategories()
//            {
//                // Arrange
//                var categories = new List<UserDTO>
//        {
//            new UserDTO { Id = 1, Name = "Zahide" },
//            new UserDTO { Id = 2, Name = "Category2" }
//        };
//                _mockCategoryService.Setup(service => service.GetAll()).Returns(categories.AsQueryable());

//                // Act
//                var result = _categoryController.GetAll();

//                // Assert
//                Assert.IsType<List<CategoryDTO>>(result);
//                Assert.Equal(categories.Count, result.Count);
//            }

//            [Fact]
//            public void Get_ShouldReturnSingleCategory()
//            {
//                // Arrange
//                var category = new CategoryDTO { Id = 1, Name = "Category1" };
//                _mockCategoryService.Setup(service => service.Get(category.Id)).Returns(category);

//                // Act
//                var result = _categoryController.Get(category.Id);

//                // Assert
//                Assert.IsType<CategoryDTO>(result);
//                Assert.Equal(category.Id, result.Id);
//                Assert.Equal(category.Name, result.Name);
//            }

//            [Fact]
//            public void Post_ShouldAddCategory()
//            {
//                // Arrange
//                var category = new AddCategoryDTO() { Name = "Category1" };
//                _mockCategoryService.Setup(service => service.Add(category)).Returns(new SuccessResult());

//                // Act
//                var result = _categoryController.Post(category);

//                // Assert
//                Assert.Equal(new SuccessResult().IsSuccessful, result.IsSuccessful);
//                _mockCategoryService.Verify(service => service.Add(category), Times.Once);
//            }

//            [Fact]
//            public void Put_ShouldUpdateCategory()
//            {
//                // Arrange
//                var id = 1;
//                var category = new UpdateCategoryDTO() { Name = "UpdatedCategory" };
//                _mockCategoryService.Setup(service => service.Update(id, category)).Returns(new SuccessResult());

//                // Act
//                var result = _categoryController.Put(id, category);

//                // Assert
//                Assert.Equal(new SuccessResult().IsSuccessful, result.IsSuccessful);
//                _mockCategoryService.Verify(service => service.Update(id, category), Times.Once);
//            }

//            [Fact]
//            public void Delete_ShouldDeleteCategory()
//            {
//                // Arrange
//                var id = 1;
//                _mockCategoryService.Setup(service => service.Delete(id)).Returns(new SuccessResult());

//                // Act
//                var result = _categoryController.Delete(id);

//                // Assert
//                Assert.Equal(new SuccessResult().IsSuccessful, result.IsSuccessful);
//                _mockCategoryService.Verify(service => service.Delete(id), Times.Once);
//            }
//        }
//    }
//}