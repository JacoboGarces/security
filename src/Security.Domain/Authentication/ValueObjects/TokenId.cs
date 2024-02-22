using Security.Domain.Generic;

namespace Security.Domain.Authentication.ValueObjects
{
  public class TokenId : Identity
  {
    public TokenId(string uuid) : base(uuid) { }

    public TokenId() : base() { }
  }
}
