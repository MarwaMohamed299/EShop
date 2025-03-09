namespace Ordering.Application.Orders.EventHandlers.Domin
{
    public class OrderCreatedEventHandler
     (ILogger<OrderCreatedEventHandler> logger)
     : INotificationHandler<OrderCreatedEvent>
    {
        public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain Event handled: {DomainEvent}", notification, GetType());
            return Task.CompletedTask;

        }
    }

}
