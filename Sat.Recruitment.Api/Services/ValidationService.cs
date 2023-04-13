using System;
using System.Collections.Generic;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Interfaces;

namespace Sat.Recruitment.Api.Services
{
    //This class could be use to do all validations
    public class ValidationService : IValidationService
    {
        public ValidationService()
        {
        }

        //Validate errors
        public void ValidateErrors(List<Field> fields, ref string errors)
        {
            foreach (Field field in fields)
            {
                if (field.Value == null)
                    errors = errors + "The " + field.Name + " is required.";
            }
        }
    }
}

