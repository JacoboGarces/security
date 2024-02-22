namespace Security.Domain.Generic
{
  public abstract class EventChange
  {
    public HashSet<Action<DomainEvent>> Actions { get; private set; } = [];

    protected void Apply<T>(Action<T> action) where T : DomainEvent
    {
      Actions.Add((Action<DomainEvent>) action);
    }
  }
}
