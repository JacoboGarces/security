using Security.Domain.Authentication.ValueObjects;
using Security.Domain.Generic;

namespace Security.Domain.Authentication.Entities
{
  public class RefreshToken : Entity<RefreshTokenId>
  {
    public ExpirationDate? ExpirationDate { get; private set; }

    public RefreshToken(RefreshTokenId identity, ExpirationDate expirationDate) : base(identity)
    {
      Generate(expirationDate);
    }

    public RefreshToken Generate(ExpirationDate expirationDate)
    {
      if (expirationDate == null)
      {
        throw new ArgumentNullException("Expiration date cannot be a null value");
      }

      if (!IsValid(expirationDate))
      {
        throw new ArgumentException("The expiration date cannot be less than today's date");
      }

      ExpirationDate = expirationDate;
      return this;
    }

    public bool IsValid(ExpirationDate? expirationDate)
    {
      return expirationDate?.GetValue().Second > DateTime.Now.Second;
    }
  }
}
  