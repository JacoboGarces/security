using Security.Domain.Generic;

namespace Security.Domain.Authentication.ValueObjects
{
  public class Password : IValueObject<string>
  {
    private readonly string _value;

    public Password()
    {
      _value = string.Empty;
    }

    private Password(string value)
    {
      _value = value;
    }

    public string GetValue()
    {
      return _value;
    }

    public IValueObject<string> Of(string value)
    {
      if (string.IsNullOrEmpty(value))
      {
        throw new ArgumentNullException("The password cannot be a null or empty value");
      }

      return new Password(value);
    }
  }
}
