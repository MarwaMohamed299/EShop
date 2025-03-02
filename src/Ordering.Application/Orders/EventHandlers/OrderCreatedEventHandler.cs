

namespace Ordering.Application.Orders.EventHandlers
{
    public class OrderCreatedEventHandler
     (ILogger<OrderCreatedEventHandler> logger)
     : INotificationHandler<OrderCreatedEvent>
    {
        public  Task Handle(OrderCreatedEvent notification,CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain Event handled: {DomainEvent}", notification, GetType());
            return Task.CompletedTask;

            //if (await featureManager.IsEnabledAsync("OrderFullfilment"))
            //{
            //    var orderCreatedIntegrationEvent = domainEvent.order.ToOrderDto();
            //    await publishEndpoint.Publish(orderCreatedIntegrationEvent, cancellationToken);
            //}
        }
    }

}
