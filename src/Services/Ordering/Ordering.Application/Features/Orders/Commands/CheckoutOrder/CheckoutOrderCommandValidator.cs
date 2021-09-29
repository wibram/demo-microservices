using FluentValidation;

namespace Ordering.Application.Features.Orders.Commands.CheckoutOrder
{
    public class CheckoutOrderCommandValidator : AbstractValidator<CheckoutOrderCommand>
    {
        public CheckoutOrderCommandValidator()
        {
            RuleFor( p => p.UserName )
                .NotNull()
                .NotEmpty().WithMessage( "{UserName} is required." )
                .MaximumLength( 50 ).WithMessage( "{UserName} must not exceed 50 characters." );

            RuleFor( p => p.EmailAddress )
                .NotNull()
                .NotEmpty().WithMessage( "{EmailAddress} is required." );

            RuleFor( p => p.TotalPrice )
                .NotNull()
                .NotEmpty().WithMessage( "{TotalPrice} is required." )
                .GreaterThan( 0 ).WithMessage( "{TotalPrice} should be greater than zero." );
        }
    }
}
