public class AuthStateProvider
{
    public bool IsLoggedIn { get; private set; }

    public void Login()
    {
        IsLoggedIn = true;
    }

    public void LogOut()
    {
        IsLoggedIn = false;
    }
}
