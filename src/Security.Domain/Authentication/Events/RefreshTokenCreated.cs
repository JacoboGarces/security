using Security.Domain.Generic;

namespace Security.Domain.Authentication.Events
{
  public class RefreshTokenCreated : DomainEvent
  {
    public DateTime ExpirationDate { get; set; }

    public RefreshTokenCreated(DateTime expirationDate) : base(EventsEnum.REFRESH_TOKEN_CREATED.ToString())
    {
      ExpirationDate = expirationDate;
    }
  }
}
