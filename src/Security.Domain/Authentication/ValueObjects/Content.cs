using Security.Domain.Generic;

namespace Security.Domain.Authentication.ValueObjects
{
  public class Content : IValueObject<string>
  {
    private readonly string _value;

    private Content(string value)
    {
      _value = value;
    }

    public Content()
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
        throw new ArgumentNullException("The content cannot be a null or empty value");
      }

      return new Content(value);
    }
  }
}
