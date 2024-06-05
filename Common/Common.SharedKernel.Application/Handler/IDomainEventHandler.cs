
using MediatR;

namespace Common.SharedKernel.Application;

public interface IDomainEventHandler<in TEvent> : INotificationHandler<TEvent>
    where TEvent : INotification;