using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Controllers;
using MyMvcApp.Models;
using Xunit;

namespace MyMvcApp.Tests
{
    public class UserControllerTests
    {
        [Fact]
        public void Index_ReturnsViewResult_WithUserList()
        {
            // Arrange
            var controller = new UserController();
            UserController.userlist = new List<User> { new User { Id = 1, Name = "John Doe", Email = "john@example.com" } };

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<User>>(viewResult.ViewData.Model);
            Assert.Single(model);
        }

        [Fact]
        public void Details_ReturnsViewResult_WithUser()
        {
            // Arrange
            var controller = new UserController();
            UserController.userlist = new List<User> { new User { Id = 1, Name = "John Doe", Email = "john@example.com" } };

            // Act
            var result = controller.Details(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<User>(viewResult.ViewData.Model);
            Assert.Equal(1, model.Id);
        }

        [Fact]
        public void Create_ReturnsViewResult()
        {
            // Arrange
            var controller = new UserController();

            // Act
            var result = controller.Create();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Create_Post_RedirectsToIndex()
        {
            // Arrange
            var controller = new UserController();
            var user = new User { Id = 1, Name = "John Doe", Email = "john@example.com" };

            // Act
            var result = controller.Create(user);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public void Edit_ReturnsViewResult_WithUser()
        {
            // Arrange
            var controller = new UserController();
            UserController.userlist = new List<User> { new User { Id = 1, Name = "John Doe", Email = "john@example.com" } };

            // Act
            var result = controller.Edit(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<User>(viewResult.ViewData.Model);
            Assert.Equal(1, model.Id);
        }

        [Fact]
        public void Edit_Post_RedirectsToIndex()
        {
            // Arrange
            var controller = new UserController();
            UserController.userlist = new List<User> { new User { Id = 1, Name = "John Doe", Email = "john@example.com" } };
            var user = new User { Id = 1, Name = "Jane Doe", Email = "jane@example.com" };

            // Act
            var result = controller.Edit(1, user);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public void Delete_ReturnsViewResult_WithUser()
        {
            // Arrange
            var controller = new UserController();
            UserController.userlist = new List<User> { new User { Id = 1, Name = "John Doe", Email = "john@example.com" } };

            // Act
            var result = controller.Delete(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<User>(viewResult.ViewData.Model);
            Assert.Equal(1, model.Id);
        }

        [Fact]
        public void Delete_Post_RedirectsToIndex()
        {
            // Arrange
            var controller = new UserController();
            UserController.userlist = new List<User> { new User { Id = 1, Name = "John Doe", Email = "john@example.com" } };

            // Act
            var result = controller.Delete(1, null);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }
    }
}