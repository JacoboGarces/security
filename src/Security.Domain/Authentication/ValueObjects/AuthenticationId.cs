using Security.Domain.Generic;

namespace Security.Domain.Authentication.ValueObjects
{
  public class AuthenticationId : Identity
  {
    public AuthenticationId(string uuid) : base(uuid) { }

    public AuthenticationId() : base() { }
  }
}
