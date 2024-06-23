using PortAudioCSharp.Devices;

namespace PortAudioCSharp.Services.Contracts;

public interface IPortAudioService : IDisposable
{
    public bool IsInitialized { get; }
    public HostApi DefaultHostApi { get; }
    public PortAudioDevice DefaultInputDevice { get; }
    public PortAudioDevice DefaultOutputDevice { get; }
    public IEnumerable<HostApi> GetAllHostApi();
    public IEnumerable<PortAudioDevice> GetAllDevice();
}
