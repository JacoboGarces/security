using Security.Domain.Authentication.Entities;
using Security.Domain.Authentication.Events;
using Security.Domain.Authentication.ValueObjects;
using Security.Domain.Generic;

namespace Security.Domain.Authentication
{
  public class AuthenticationEventChange : EventChange
  {
    public AuthenticationEventChange(AuthenticationAggregate aggregate)
    {
      Apply((TokenCreated tokenCreated) =>
      {
        if (!tokenCreated.RefreshTokenId.Equals(aggregate.RefreshToken?.Identity.GetValue()))
        {
          throw new InvalidOperationException("Refresh token doesn't match");
        }

        if (!aggregate.RefreshToken.IsValid(aggregate.RefreshToken.ExpirationDate))
        {
          throw new InvalidOperationException("Refresh token was expired, generate a new refresh token");
        }

        var content = (Content)new Content().Of(tokenCreated.Content);
        var expirationDate = (ExpirationDate)new ExpirationDate().Of(tokenCreated.ExpirationDate);
        var secretKey = (SecretKey)new SecretKey().Of(tokenCreated.SecretKey);

        var token = new Token(new TokenId(), content, expirationDate, secretKey);

        aggregate.Token = token;
      });

      Apply((RefreshTokenCreated refreshTokenCreated) =>
      {
        var expirationDate = (ExpirationDate)new ExpirationDate().Of(refreshTokenCreated.ExpirationDate);

        var refreshToken = new RefreshToken(new RefreshTokenId(), expirationDate);

        aggregate.RefreshToken = refreshToken;
      });

      Apply((CredentialesAdded credentialesAdded) =>
      {
        var email = (Email)new Email().Of(credentialesAdded.Email);
        var password = (Password)new Password().Of(credentialesAdded.Password);

        aggregate.Credentials = new Credentials(new CredentialsId(), email, password);
      });

      Apply((Authenticated authenticated) =>
      {
        if (aggregate.Credentials == null)
        {
          throw new InvalidOperationException("No credentials provided");
        }

        var email = (Email)new Email().Of(authenticated.Email);
        var password = (Password)new Password().Of(authenticated.Password);

        aggregate.Credentials?.Authenticate(email, password);
      });

      Apply((Logout logout) =>
      {
        aggregate.Credentials = null;
        aggregate.Token = null;
        aggregate.RefreshToken = null;
      });
    }
  }
}
