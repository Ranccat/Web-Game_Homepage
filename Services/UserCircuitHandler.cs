using Microsoft.AspNetCore.Components.Server.Circuits;

public class UserCircuitHandler : CircuitHandler
{
    private readonly UserSessionService _sessionService;

    public UserCircuitHandler(UserSessionService sessionService)
    {
        _sessionService = sessionService;
    }

    public override Task OnCircuitOpenedAsync(Circuit circuit, CancellationToken cancellationToken)
    {
        _sessionService.CreateSession(circuit.Id);
        Console.WriteLine($"New client connected: {circuit.Id}");
        return Task.CompletedTask;
    }

    public override Task OnConnectionUpAsync(Circuit circuit, CancellationToken cancellationToken)
    {
        _sessionService.UpdateConnectionStatus(circuit.Id, true);
        return Task.CompletedTask;
    }

    public override Task OnConnectionDownAsync(Circuit circuit, CancellationToken cancellationToken)
    {
        _sessionService.UpdateConnectionStatus(circuit.Id, false);
        return Task.CompletedTask;
    }

    public override Task OnCircuitClosedAsync(Circuit circuit, CancellationToken cancellationToken)
    {
        _sessionService.RemoveSession(circuit.Id);
        return Task.CompletedTask;
    }
}
