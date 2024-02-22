using Security.Domain.Generic;

namespace Security.Domain.Authentication.ValueObjects
{
  public class ExpirationDate : IValueObject<DateTime>
  {
    private readonly DateTime _value;

    private ExpirationDate(DateTime value)
    {
      _value = value;
    }

    public ExpirationDate()
    {
    }

    public DateTime GetValue()
    {
      return _value;
    }

    public IValueObject<DateTime> Of(DateTime value)
    {
      if (value.Second <= 0)
      {
        throw new ArgumentException("The expiration date cannot be less than or equal to 0");
      }

      return new ExpirationDate(value);
    }
  }
}
