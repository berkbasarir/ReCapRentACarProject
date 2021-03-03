using Entities.Concrete;
using FluentValidation;
using System;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MinimumLength(2);
            RuleFor(p => p.DailyPrice).NotEmpty();
            RuleFor(p => p.DailyPrice).GreaterThan(0);
            RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(150).When(p => p.BrandId == 1);
            RuleFor(p => p.Name).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı!");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}