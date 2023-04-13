using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Services;
using Sat.Recruitment.Api.Interfaces;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase, IUsers
    {
        private readonly List<User> _users = new List<User>();
        private readonly IValidationService _validationService;

        public UsersController(IValidationService validationService)
        {
            _validationService = validationService;
        }

        ~UsersController()
        {
        }

        [HttpPost]
        [Route("/validate-user")]
        public async Task<Result> ValidateUser(User user)
        {
            //Here we validate the data of the user.
            string errors = "";

            List<Field> _fields = new List<Field>();
            _fields.Add(new Field(user.Name, "name"));
            _fields.Add(new Field(user.Email, "email"));
            _fields.Add(new Field(user.Address, "address"));
            _fields.Add(new Field(user.Phone, "phone"));

            _validationService.ValidateErrors(_fields, ref errors);

            if (errors != null && errors != "")
                return new Result(false, errors);
            else return new Result(true, "Valid User");

        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<Result> CreateUser(User newUser)
        {
            //Here we create the user.
            try
            {
                bool isDuplicated = await checkIfUserIsDuplicated(newUser);

                if (!isDuplicated)
                {
                    //Here is qhere the logic to create a user in the DB should be

                    Debug.WriteLine("User Created");

                    return new Result(true, "User Created");
                }
                else
                {
                    Debug.WriteLine("The user is duplicated");

                    return new Result(false, "The user is duplicated");
                }
            }
            catch
            {
                Debug.WriteLine("The user is duplicated");
                return new Result(false, "The user is duplicated");
            }

        }

    }
}
