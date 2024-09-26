public class UserSession
{
    public string CircuitId { get; set; } = string.Empty;
    public bool IsConnected { get; set; } = false;
    public bool IsLoggedIn { get; set; } = false;

    public string UserId { get; set; } = string.Empty;
    public DateTime LastLogin { get; set; }
}
