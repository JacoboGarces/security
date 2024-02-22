namespace Security.Domain.Generic
{
  public abstract class DomainEvent
  {
    public DateTime Moment { get; private set; }
    public long Version { get; set; }
    public string UUID { get; private set; }
    public string Type { get; private set; }
    public string? AggregateRootId { get; set; }
    public string? AggregateRootName { get; set; }
    public string? AggregateParentId { get; set; }

    protected DomainEvent( string type, string aggregateRootId, string aggregateRootName, string aggregateParentId )
    {
      Moment = DateTime.Now;
      UUID = Guid.NewGuid().ToString();
      Type = type;
      AggregateRootId = aggregateRootId;
      AggregateRootName = aggregateRootName;
      AggregateParentId = aggregateParentId;
      Version = 1;
    }

    protected DomainEvent( string type )
    {
      Moment = DateTime.Now;
      UUID = Guid.NewGuid().ToString();
      Type = type;
      Version = 1;
    }
  }
}
