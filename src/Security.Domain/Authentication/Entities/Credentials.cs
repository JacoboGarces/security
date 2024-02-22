using Security.Domain.Authentication.ValueObjects;
using Security.Domain.Generic;

namespace Security.Domain.Authentication.Entities
{
  public class Credentials : Entity<CredentialsId>
  {
    public Email? Email { get; private set; }
    public Password? Password { get; private set; }
    public IsAuthenticated? IsAuthenticated { get; private set; }

    public Credentials(CredentialsId identity, Email email, Password password) : base(identity)
    {
      AddCredentials(email, password, new IsAuthenticated());
    }

    private void AddCredentials(Email email, Password password, IsAuthenticated isAuthenticated)
    {
      Email = email;
      Password = password;
      IsAuthenticated = isAuthenticated;
    }

    public bool Authenticate(Email email, Password password)
    {
      if (email.GetValue().Equals(Email?.GetValue()) && password.GetValue().Equals(Password?.GetValue()))
      {
        IsAuthenticated = IsAuthenticated?.Of(true) as IsAuthenticated;
        return true;
      }

      throw new InvalidOperationException("Wrong credentials");
    }
  }
}
