using Microsoft.AspNetCore.Components.Server.Circuits;

public class UserSessionService
{
    private readonly Dictionary<string, UserSession> _sessions = new();

    public void CreateSession(string circuitId)
    {
        _sessions[circuitId] = new UserSession { CircuitId = circuitId };
    }

    public void Login(string userId, DateTime loginDate)
    {
        // 
    }

    public void UpdateConnectionStatus(string circuitId, bool isConnected)
    {
        if (_sessions.ContainsKey(circuitId))
        {
            _sessions[circuitId].IsConnected = isConnected;
        }
    }

    public void RemoveSession(string circuitId)
    {
        if (_sessions.ContainsKey(circuitId))
        {
            _sessions.Remove(circuitId);
        }
    }

    public string GetCircuitId()
    {
        return CircuitHandler.
    }
}
