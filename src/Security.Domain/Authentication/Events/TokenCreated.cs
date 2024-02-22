using Security.Domain.Generic;

namespace Security.Domain.Authentication.Events
{
  public class TokenCreated : DomainEvent
  {
    public string Content { get; set; }
    public string SecretKey { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string RefreshTokenId { get; set; }

    public TokenCreated(string content, string secretKey, DateTime expirationDate, string refreshTokenId) : base(EventsEnum.TOKEN_CREATED.ToString())
    {
      Content = content;
      SecretKey = secretKey;
      ExpirationDate = expirationDate;
      RefreshTokenId = refreshTokenId;
    }
  }
}
