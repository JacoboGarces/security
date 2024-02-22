using Security.Domain.Authentication.ValueObjects;
using Security.Domain.Generic;

namespace Security.Domain.Authentication.Entities
{
  public class Token : Entity<TokenId>
  {
    public Content Content { get; private set; }
    public ExpirationDate ExpirationDate { get; private set; }
    public SecretKey SecretKey { get; private set; }

    public Token(TokenId identity, Content content, ExpirationDate expirationDate, SecretKey secretKey) : base(identity)
    {
      Content = content;
      ExpirationDate = expirationDate;
      SecretKey = secretKey;
    }

    public Token Refresh(string content)
    {
      if (IsValid())
      {
        Content = (Content)new Content().Of(content + SecretKey.GetValue());
      }

      return this;
    }

    public bool IsValid()
    {
      bool isExpired = ExpirationDate.GetValue().Second > DateTime.Now.Second;
      bool isEmpty = string.IsNullOrEmpty(Content.GetValue());

      return isExpired && isEmpty;
    }
  }
}
