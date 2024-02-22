using Security.Domain.Generic;

namespace Security.Domain.Authentication.Events
{
  public class Authenticated : DomainEvent
  {
    public string Email { get; set; }
    public string Password { get; set; }

    public Authenticated(string email, string password) : base(EventsEnum.AUTHENTICATED.ToString())
    {
      Email = email;
      Password = password;
    }
  }
}
