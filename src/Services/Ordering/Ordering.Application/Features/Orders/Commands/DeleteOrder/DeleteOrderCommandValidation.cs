using System;
using FluentValidation;

namespace Ordering.Application.Features.Orders.Commands.DeleteOrder
{
	public class DeleteOrderCommandValidation : AbstractValidator<DeleteOrderCommand>
	{
		public DeleteOrderCommandValidation()
		{
			RuleFor(p => p.Id)
				.NotNull().WithMessage("{Id} cannnot be empty");
		}
	}
}

