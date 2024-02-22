using Security.Domain.Generic;

namespace Security.Domain.Authentication.Events
{
  public class CredentialesAdded : DomainEvent
  {
    public string Email { get; set; }
    public string Password { get; set; }

    public CredentialesAdded(string email, string password) : base(EventsEnum.CREDENTIALS_ADDED.ToString())
    {
      Email = email;
      Password = password;
    }
  }
}
