using Security.Domain.Generic;

namespace Security.Domain.Authentication.ValueObjects
{
  public class CredentialsId : Identity
  {
    public CredentialsId(string uuid) : base(uuid) { }

    public CredentialsId() : base() { }
  }
}
