namespace PortAudioCSharp.Services.Contracts;

public interface IPortAudioService : IDisposable
{
    public bool IsInitialized { get; }
    public HostApi DefaultHostApi { get; }
}
