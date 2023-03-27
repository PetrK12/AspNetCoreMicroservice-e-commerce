using System;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Persistance;
using Ordering.Application.Exceptions;
using Ordering.Domain.Entities;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder
{
	public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
	{
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateOrderCommandHandler> _logger;

        public UpdateOrderCommandHandler(IOrderRepository repository, IMapper mapper, ILogger<UpdateOrderCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetByIsAsync(request.Id);
            if (order == null )
            {
                _logger.LogError($"Order with id: {request.Id} does not exists");
                throw new NotFoundException(nameof(Order), request.Id);
            }
            _ = _mapper.Map(request, order, typeof(UpdateOrderCommand), typeof(Order));

            await _repository.UpdateAsync(order);

            _logger.LogInformation($"Order {order.Id} is successfully updated");

            return Unit.Value;
        }
    }
}

