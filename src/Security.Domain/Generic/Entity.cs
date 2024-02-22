namespace Security.Domain.Generic
{
  public abstract class Entity<I> where I : Identity
  {
    public I Identity { get; private set; }

    public Entity( I identity )
    {
      if ( identity == null )
      {
        throw new ArgumentNullException( nameof( identity ), "The identity cannot be a null value" );
      }

      Identity = identity;
    }
  }
}
