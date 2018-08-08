using FinPort.Core.Models;
using FinPort.Data;
using FinPort.Services.User;
using Moq;
using System;
using Xunit;

namespace FinPort.Service.Tests
{
    public class UserRegistrationServiceTests
    {



        [Fact]
        public void user_should_exists()
        {
            // arrange
            var userService = new Mock<IUserService>();

            UserRegistrationService ur = new UserRegistrationService(userService.Object);

            string username = "bleonardo";
            bool exists = false;

            // act
            bool result = ur.UserExists(username);

            Assert.Equal(exists, result);

        }

        [Fact]
        public void register_user()
        {
            // arrange
            var userService = new Mock<IUserService>();
            Users usr = new Users()
            {
                Email = "bleonardo@email.com",
                FirstName = "Bruno",
                LastName = "Leonardo",
                Password = "bruno123",
                Username = "bleonardo"
            };

            userService.Setup(x => x.InsertUser(usr)).Returns(usr);

            UserRegistrationService ur = new UserRegistrationService(userService.Object);

            // act
            Users res = ur.RegisterUser(usr);

            Assert.Equal(usr, res);

        }
    }
}
