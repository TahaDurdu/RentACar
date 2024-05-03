﻿using System;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
	public class CarValidator:AbstractValidator<Car>
	{

		public CarValidator()
		{
			RuleFor(p => p.CarName).NotEmpty();
			RuleFor(p => p.CarName).MinimumLength(2);
			RuleFor(p => p.DailyPrice).GreaterThan(0);
			RuleFor(p => p.DailyPrice).NotEmpty();
			RuleFor(p => p.ModelYear).NotEmpty();
		}
	}
}
