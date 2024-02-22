using Security.Domain.Generic;

namespace Security.Domain.Authentication.Events
{
  public class Logout : DomainEvent
  {
    public Logout() : base(EventsEnum.LOGOUT.ToString())
    {
    }
  }
}
