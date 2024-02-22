using Security.Domain.Generic;

namespace Security.Domain.Authentication.ValueObjects
{
  public class SecretKey : IValueObject<string>
  {
    private readonly string _value;

    public SecretKey(string value)
    {
      _value = value;
    }

    public SecretKey()
    {
      _value = string.Empty;
    }

    public string GetValue()
    {
      return _value;
    }

    public IValueObject<string> Of(string value)
    {
      if (string.IsNullOrEmpty(value))
      {
        throw new ArgumentNullException("The secret key cannot be a null or empty value");
      }

      return new SecretKey(value);
    }
  }
}
