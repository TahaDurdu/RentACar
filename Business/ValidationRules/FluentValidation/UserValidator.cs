using System;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
	public class UserValidator:AbstractValidator<User>
	{
		public UserValidator()
		{
			RuleFor(p => p.FirstName).NotEmpty();
			RuleFor(p => p.FirstName).NotEmpty();
			RuleFor(p => p.Email).EmailAddress().When(p => !string.IsNullOrEmpty(p.Email));
			RuleFor(p => p.Password).NotEmpty();
		}
	}
}

