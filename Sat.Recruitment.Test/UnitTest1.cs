using System;
using System.Dynamic;

using Microsoft.AspNetCore.Mvc;

using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Services;

using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTest1
    {
        UsersController userController = new UsersController(new ValidationService());

        [Fact]
        public void Test1()
        {
            //Test for Creating a New User
            Result result;
            User userToBeCreated = new User("Mike", "mike@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", decimal.Parse("124"));

            result = userController.ValidateUser(userToBeCreated).Result;
            if (result.IsSuccess)
            {
                result = userController.CreateUser(userToBeCreated).Result;
            }

            Assert.True(result.IsSuccess);
            Assert.Equal("User Created", result.Message);
        }

        [Fact]
        public void Test2()
        {
            //Test for a New User Duplicate
            Result result;
            User userToBeCreated = new User("Agustina", "Agustina@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", decimal.Parse("124"));

            result = userController.ValidateUser(userToBeCreated).Result;
            if(result.IsSuccess)
            {
                result = userController.CreateUser(userToBeCreated).Result;
            }

            Assert.False(result.IsSuccess);
            Assert.Equal("The user is duplicated", result.Message);
        }

        ~UnitTest1()
        {
            userController = null;
        }
    }
}
