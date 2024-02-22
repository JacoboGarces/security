using Security.Domain.Generic;

namespace Security.Domain.Authentication.ValueObjects
{
  public class RefreshTokenId : Identity
  {
    public RefreshTokenId(string uuid) : base(uuid) { }

    public RefreshTokenId() : base() { }
  }
}
