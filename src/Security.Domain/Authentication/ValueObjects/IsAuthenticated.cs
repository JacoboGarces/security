using Security.Domain.Generic;

namespace Security.Domain.Authentication.ValueObjects
{
  public class IsAuthenticated : IValueObject<bool>
  {
    private readonly bool _value;

    private IsAuthenticated(bool value)
    {
      _value = value;
    }

    public IsAuthenticated()
    {
      _value = false;
    }

    public bool GetValue()
    {
      return _value;
    }

    public IValueObject<bool> Of(bool value)
    {
      return new IsAuthenticated(value);
    }
  }
}
