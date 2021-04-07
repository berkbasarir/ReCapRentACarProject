using Entities.Concrete;
using FluentValidation;
using System;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.Description).MinimumLength(3);
            RuleFor(c => c.Name).Must(StartWithA).WithMessage("Ürünler C harfi ile başlamalı");

            RuleFor(car => car.FindexPoint).GreaterThanOrEqualTo(0);
            RuleFor(car => car.FindexPoint).LessThanOrEqualTo(1900);
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("C");
        }
    }
}