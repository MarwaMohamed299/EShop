using MassTransit;
using MassTransit.Transports;
using Microsoft.FeatureManagement;
using Ordering.Domain.Abstractions;

namespace Ordering.Application.Orders.EventHandlers.Domin
{
    public class OrderCreatedEventHandler
     (ILogger<OrderCreatedEventHandler> logger , IPublishEndpoint publishEndpoint , IFeatureManager featureManager)
     : INotificationHandler<OrderCreatedEvent>
    {
        public async  Task Handle(OrderCreatedEvent domainEvent, CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain Event handled: {DomainEvent}", domainEvent, GetType());

            if ( await featureManager.IsEnabledAsync("OrderFullfilment"))
            {
            var orderCreatedIntegrationEvent = domainEvent.order.ToOrderDto();

            await publishEndpoint.Publish(orderCreatedIntegrationEvent, cancellationToken);
            }


        }
    }

}
