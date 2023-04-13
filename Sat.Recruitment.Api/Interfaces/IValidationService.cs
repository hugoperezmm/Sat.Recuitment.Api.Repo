using System.Collections.Generic;
using Sat.Recruitment.Api.Models;

namespace Sat.Recruitment.Api.Interfaces
{
    public interface IValidationService
    {
        void ValidateErrors(List<Field> fields, ref string errors);
    }
}