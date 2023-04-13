using System;
namespace Sat.Recruitment.Api.Models
{
    //Model for the result we get from requests.
	public class Result
    {
        private bool _IsSuccess { get; set; }
        private string _Message { get; set; }

        public bool IsSuccess { get { return _IsSuccess; } }
        public string Message { get { return _Message; } }

        public Result(bool isSuccess, string message)
		{
            _IsSuccess = isSuccess;
            _Message = message;
		}
	}
}

