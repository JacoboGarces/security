namespace Security.Domain.Generic
{
  public class Identity : IValueObject<string>
  {
    private string _uuid;

    protected Identity( string uuid )
    {
      _uuid = uuid;
    }

    protected Identity()
    {
      _uuid = GenerateUUID();
    }

    public IValueObject<string> Of( string value )
    {
      if ( string.IsNullOrEmpty( value ) )
      {
        throw new ArgumentNullException( "The uuid cannot be a null or empty value" );
      }

      return new Identity( value );
    }

    public string GetValue()
    {
      return _uuid;
    }

    private string GenerateUUID()
    {
      return Guid.NewGuid().ToString();
    }
  }
}
