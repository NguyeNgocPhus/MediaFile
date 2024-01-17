namespace PNN.Identity.Abstraction;
public interface IIdentityService
{
    public T? GetToken<T>();
    public T ValidateToken<T>(string token);
    public T GenerateToken<U,T>(U payload);
}
