using System;
using Sat.Recruitment.Api.Models;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Interfaces
{
    //Interface for the Users
	public interface IUsers
	{
        //Here plan all the methods that are going to be needed to work with users in general.
        public Task<Result> ValidateUser(User user);
        public Task<Result> CreateUser(User newUser);
    }
}

