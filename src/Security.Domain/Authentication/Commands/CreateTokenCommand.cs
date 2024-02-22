namespace Security.Domain.Authentication.Commands
{
  public class CreateTokenCommand
  {
    public string? Content { get; set; }
    public string? SecretKey { get; set; }
    public DateTime ExpirationDate { get; set; }
  }
}
