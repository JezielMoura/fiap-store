using MediatR;

namespace FiapStore.Domain.Shared;

public class Entity
{
    private readonly IList<INotification> _events = new List<INotification>();

    public Guid Id { get; set; }
    public IEnumerable<INotification> DomainEvents => _events.AsReadOnly();

    public void AddEvent(INotification @event) =>
        _events.Add(@event);

    public void Clear() =>
        _events.Clear();
}