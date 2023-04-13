using System;
namespace Sat.Recruitment.Api.Models
{
	//Model for the fields we are using to create or generate a Model, like a User
	public class Field
	{
		private string _Value { get; set; }
		private string _Name { get; set; }

		public string Value { get { return _Value; } }
		public string Name { get { return _Name; } }

		public Field(string value, string name)
		{
			_Value = value;
			_Name = name;
		}
	}
}

