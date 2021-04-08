
using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerUpdateValidator : AbstractValidator<CustomersDetailDto>
    {
        public CustomerUpdateValidator()
        {
            RuleFor(customerDetail => customerDetail.id).NotEmpty();
            RuleFor(customerDetail => customerDetail.UserId).NotEmpty();
            RuleFor(customerDetail => customerDetail.FirstName).NotEmpty().MinimumLength(2);
            RuleFor(customerDetail => customerDetail.LastName).NotEmpty().MinimumLength(2);
            RuleFor(customerDetail => customerDetail.Email).NotEmpty();
        }
    }
}