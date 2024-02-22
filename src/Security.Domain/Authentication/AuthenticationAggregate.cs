using Security.Domain.Authentication.Entities;
using Security.Domain.Authentication.Events;
using Security.Domain.Authentication.ValueObjects;
using Security.Domain.Generic;

namespace Security.Domain.Authentication
{
  public class AuthenticationAggregate : AggregateRoot<AuthenticationId>
  {
    public Token? Token { get; set; }
    public RefreshToken? RefreshToken { get; set; }
    public Credentials? Credentials { get; set; }

    public AuthenticationAggregate(AuthenticationId identity) : base(identity)
    {
      Subscribe(new AuthenticationEventChange(this));
    }

    public static void From(AuthenticationId id, List<DomainEvent> events)
    {
      var authentication = new AuthenticationAggregate(id);
      events.ForEach(authentication.ApplyEvent);
    }

    public void AddToken(string content, DateTime expirationDate, string secretKey, string refreshTokenId)
    {
      AppendEvent(new TokenCreated(content, secretKey, expirationDate, refreshTokenId)).Invoke();
    }

    public void GenerateRefreshToken(DateTime expirationDate, string content, DateTime tokenExpirationDate, string secretKey)
    {
      AppendEvent(new RefreshTokenCreated(expirationDate)).Invoke();
      AddToken(content, tokenExpirationDate, secretKey, RefreshToken.Identity.GetValue());
    }

    public void AddCredentials(string email, string password)
    {
      AppendEvent(new CredentialesAdded(email, password)).Invoke();
    }

    public void Authenticate(string email, string password, DateTime expirationDate, string content, DateTime tokenExpirationDate, string secretKey)
    {
      AppendEvent(new Authenticated(email, password)).Invoke();

      if (Credentials.IsAuthenticated.GetValue())
      {
        GenerateRefreshToken(expirationDate, content, tokenExpirationDate, secretKey);
      }
    }

    public void Logout()
    {
      AppendEvent(new Logout()).Invoke();
    }
  }
}
