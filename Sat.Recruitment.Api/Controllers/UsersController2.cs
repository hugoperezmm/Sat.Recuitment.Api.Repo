using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using Sat.Recruitment.Api.Models;

namespace Sat.Recruitment.Api.Controllers
{
    public partial class UsersController
    {
        private StreamReader ReadUsersFromFile()
        {
            //Medoth to fetch the users.

            var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";

            FileStream fileStream = new FileStream(path, FileMode.Open);

            StreamReader reader = new StreamReader(fileStream);
            return reader;
        }

        private async Task<bool> checkIfUserIsDuplicated(User newUser)
        {
            //Method to check if a user is duplicated.

            var reader = ReadUsersFromFile();
            while (reader.Peek() >= 0)
            {
                var line = reader.ReadLineAsync().Result;
                var user = new User(line.Split(',')[0].ToString(), line.Split(',')[1].ToString(), line.Split(',')[2].ToString(), line.Split(',')[3].ToString(),
                    line.Split(',')[4].ToString(), decimal.Parse(line.Split(',')[5].ToString()));
                _users.Add(user);
            }
            reader.Close();


            foreach (var user in _users)
            {
                if (user.Email == newUser.Email
                    ||
                    user.Phone == newUser.Phone)
                {
                    return true;
                }
                else if (user.Name == newUser.Name)
                {
                    if (user.Address == newUser.Address)
                    {
                        return true;
                        throw new Exception("User is duplicated");
                    }

                }
            }

            return false;
        }
    }
}
