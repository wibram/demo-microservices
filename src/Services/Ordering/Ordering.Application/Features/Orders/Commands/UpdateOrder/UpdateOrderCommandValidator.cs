﻿using FluentValidation;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
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
