using Security.Domain.Generic;

namespace Security.Domain.Authentication.ValueObjects
{
  public class Email : IValueObject<string>
  {
    private readonly string _value;

    public Email()
    {
      _value = string.Empty;
    }

    private Email(string value)
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
        throw new ArgumentNullException("The email cannot be a null or empty value");
      }

      return new Email(value);
    }
  }
}
