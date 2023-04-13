using System;
using System.Security.Policy;

namespace Sat.Recruitment.Api.Models
{
    //Model for Users here is where the fields that are going to define a user are, and also here are validated, manipulated and where they should be added.
    public class User
    {
        private string _Name { get; set; }
        private string _Email { get; set; }
        private string _Address { get; set; }
        private string _Phone { get; set; }
        private string _UserType { get; set; }
        private decimal _Money { get; set; }

        public string Name
        {
            get { return _Name; }
        }
        public string Email
        {
            get { return _Email; }
        }
        public string Address
        {
            get { return _Address; }
        }
        public string Phone
        {
            get { return _Phone; }
        }
        public string UserType
        {
            get { return _UserType; }
        }
        public decimal Money
        {
            get { return _Money; }
        }

        public User(string Name, string Email, string Address, string Phone, string UserType, decimal Money)
        {
            _Name = Name;
            _Email = normalizeEmail(Email);
            _Address = Address;
            _Phone = Phone;
            _UserType = UserType;
            _Money = calculateMoneyByUserType(UserType, Money);
        }

        decimal calculateMoneyByUserType(string userType, decimal money)
        {
            decimal result;
            decimal percentage = 0;
            switch (userType)
            {
                case "SuperUser":
                    if (money > 100) percentage = Convert.ToDecimal(0.20);
                    break;

                case "Premium":
                    if (money > 100) percentage = 2;
                    break;

                default:
                    if (money > 100)
                    {
                        percentage = Convert.ToDecimal(0.12);
                    }
                    else 
                    {
                        percentage = Convert.ToDecimal(0.8);
                    }
                    break;
            }
            var gif = money * percentage;
            result = money + gif;

            return result;

        }

        string normalizeEmail(string email)
        {
            //Normalize email
            var aux = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            return string.Join("@", new string[] { aux[0], aux[1] });
        }
    }
}

