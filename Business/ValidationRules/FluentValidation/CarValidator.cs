using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.CarName).NotNull();
            RuleFor(p => p.CarName).MinimumLength(3).MaximumLength(15);
            RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(0).When(p => p.BrandId == 1);
            RuleFor(p => p.CarName).Must(StartWithB).WithMessage("İsim A harfi ile başlamıyor!!");
        }

        private bool StartWithB(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
