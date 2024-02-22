using System;

namespace Security.Domain.Generic
{
  public class EventSubscriber
  {
    public List<DomainEvent> Events { get; } = [];
    private readonly HashSet<Action<DomainEvent>> _actions = [];
    private readonly Dictionary<string, long> _versions = [];

    public void Subscribe(EventChange eventChange)
    {
      _actions.UnionWith(eventChange.Actions);
    }

    public Action AppendChange(DomainEvent @event)
    {
      Events.Add(@event);
      return () => Apply(@event);
    }

    public void Apply(DomainEvent @event)
    {
      foreach (var action in _actions)
      {
        action.Invoke(@event);

        if (@event is IIncremental)
        {
          long version = NextVersion(@event);
          @event.Version = version;
        }
      }
    }

    private long NextVersion(DomainEvent @event)
    {
      if (_versions.ContainsKey(@event.Type))
      {
        _versions.TryGetValue(@event.Type, out long version);
        return _versions[@event.Type] = version + 1;
      }

      _versions.Add(@event.Type, @event.Version);
      return _versions[@event.Type];
    }
  }
}
