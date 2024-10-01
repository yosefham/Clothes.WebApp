using FluentValidation;

namespace Clothes.Api.Models.Validators;

public class FilterResourceValidator : AbstractValidator<FilterResource>
{
    public FilterResourceValidator()
    {
        RuleFor(x => x.MinPrice).NotNull().GreaterThanOrEqualTo(0)
            .WithMessage(x => $"MinPrice must be equal to or greater than 0. Provided value: {x.MinPrice}");
        RuleFor(x => x.MaxPrice).NotNull().GreaterThanOrEqualTo(0)
            .WithMessage(x => $"MaxPrice must be equal to or greater than 0. Provided value: {x.MaxPrice}");
        
        RuleFor(x => x.MinPrice).LessThanOrEqualTo(x => x.MaxPrice)
            .WithMessage(x => $"MinPrice must be less than or equal to MaxPrice. Provided values: MinPrice={x.MinPrice}, MaxPrice={x.MaxPrice}");
    }
}