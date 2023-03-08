namespace WebAPi.InterfaceFunction
{
    public interface JwtAuthenticationManager
    {
        string Authentication(string username, string password);
    }
}
