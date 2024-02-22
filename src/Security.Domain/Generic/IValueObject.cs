namespace Security.Domain.Generic
{
  public interface IValueObject<T>
  {
    IValueObject<T> Of( T value );
    T GetValue(); 
  }
}
