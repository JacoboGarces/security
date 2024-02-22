namespace Security.Domain.Generic
{
  public abstract class AggregateRoot<I> : Entity<I> where I : Identity
  {
    private readonly EventSubscriber _eventSubscriber;

    public AggregateRoot(I identity) : base(identity)
    {
      _eventSubscriber = new();
    }

    public List<DomainEvent> GetUncomittedEvents()
    {
      return _eventSubscriber.Events.ToList();
    }

    protected Action AppendEvent(DomainEvent domainEvent)
    {
      string aggregateName = this.GetType().Name.ToLower();
      domainEvent.AggregateRootName = aggregateName;
      domainEvent.AggregateRootId = Identity.GetValue();
      return _eventSubscriber.AppendChange(domainEvent);
    }

    protected void Subscribe(EventChange eventChange)
    {
      _eventSubscriber.Subscribe(eventChange);
    }

    protected void ApplyEvent(DomainEvent domainEvent)
    {
      _eventSubscriber.Apply(domainEvent);
    }

    public void ClearEvents()
    {
      _eventSubscriber.Events.Clear();
    }
  }
}
